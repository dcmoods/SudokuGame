﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Sudoku.Client.Wrapper
{
    public class ModelWrapper<T> : NotifyDataErrorInfoBase, IValidatableTrackingObject, IValidatableObject   
    {

        private Dictionary<string, object> _originalValues;
        private List<IValidatableTrackingObject> _trackingObjects;

        public ModelWrapper(T model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }
            Model = model;
            _originalValues = new Dictionary<string, object>();
            _trackingObjects = new List<IValidatableTrackingObject>();
            InitializeComplexProperties(model);
            InitializeCollectionProperties(model);
            Validate();      
        }
        
        protected virtual void InitializeComplexProperties(T model)
        {
        }

        protected virtual void InitializeCollectionProperties(T model)
        {
        }

        public T Model { get; private set; }        

        public bool IsChanged => _originalValues.Count > 0 || _trackingObjects.Any(t => t.IsChanged); 

        public bool IsValid => !HasErrors && _trackingObjects.All(t => t.IsValid); 
        
        public void AcceptChanges()
        {
            
            _originalValues.Clear();            
            foreach (var trackingObject in _trackingObjects)
            {                
                trackingObject.AcceptChanges();
            }
            //Empty string or null OnPropertyChanged grabs updates 
            //all data bindings model wrapper current value.
            //Refreshes whole object in UI.
            OnPropertyChanged(""); 
        }

       

        public void RejectChanges()
        {      
            
            foreach (var originalValueEnrty in _originalValues)
            {
                //Use reflection of the model type to get property 
                //name and set property value to original value
                typeof(T).GetProperty(originalValueEnrty.Key).SetValue(Model, originalValueEnrty.Value);
            }
            _originalValues.Clear();
            foreach (var trackingObject in _trackingObjects)
            {
                trackingObject.RejectChanges();
            }
            Validate();
            OnPropertyChanged("");
        }


        protected TValue GetValue<TValue>([CallerMemberName] string propertyName = null)
        {
            var propertyInfo = Model.GetType().GetProperty(propertyName);
            return (TValue)propertyInfo.GetValue(Model);           
        }

        protected TValue GetOriginalValue<TValue>(string propertyName)
        {
            return _originalValues.ContainsKey(propertyName) ? 
                   (TValue)_originalValues[propertyName] : 
                   GetValue<TValue>(propertyName);
        }

        protected bool GetIsChanged(string propertyName)
        {
            return _originalValues.ContainsKey(propertyName);
        }

        protected void SetValue<TValue>(TValue newValue,
            [CallerMemberName] string propertyName = null)
        {
            var propertyInfo = Model.GetType().GetProperty(propertyName);
            var currentValue = propertyInfo.GetValue(Model);
            if (!Equals(currentValue, newValue))
            {
                UpdateOriginalValue(currentValue, newValue, propertyName);                
                propertyInfo.SetValue(Model, newValue);
                Validate();
                OnPropertyChanged(propertyName);
                OnPropertyChanged(propertyName + "IsChanged");
            }
        }

        private void Validate()
        {
            ClearErrors();
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var context = new ValidationContext(this);
            Validator.TryValidateObject(this, context, results, true);
            if(results.Any())
            {
                var propertyNames = results.SelectMany(r => r.MemberNames).Distinct().ToList();

                foreach (var propertyName in propertyNames)
                {
                    Errors[propertyName] = results.Where(r => r.MemberNames.Contains(propertyName))
                                                  .Select(r => r.ErrorMessage).Distinct().ToList();
                    OnErrorsChanged(propertyName);
                }
            }
            OnPropertyChanged(nameof(IsValid));
        }

        private void UpdateOriginalValue(object currentValue, object newValue, string propertyName)
        {
            if (!_originalValues.ContainsKey(propertyName))
            {
                _originalValues.Add(propertyName, currentValue);
                OnPropertyChanged("IsChanged");
            }
            else
            {
                if(Equals(_originalValues[propertyName], newValue))
                {
                    _originalValues.Remove(propertyName);
                    OnPropertyChanged("IsChanged");
                }
            }
        }


        protected void RegisterCollection<TWrapper, TModel>(ChangeTrackingCollection<TWrapper> wrapperCollection,
                                List<TModel> modelCollection) where TWrapper : ModelWrapper<TModel> 
        {
            wrapperCollection.CollectionChanged += (s, e) =>
            {
                modelCollection.Clear();
                modelCollection.AddRange(wrapperCollection.Select(w => w.Model));

                if (e.OldItems != null)
                {
                    foreach(var item in e.OldItems.Cast<TWrapper>())
                    {
                    }
                }
                if(e.NewItems != null)
                {
                    foreach (var item in e.NewItems.Cast<TWrapper>())
                    {
                        modelCollection.Add(item.Model);                       
                    }
                }
            };
            RegisterTrackingObject(wrapperCollection);
        }

        protected void RegisterComplex<TModel>(ModelWrapper<TModel> wrapper) where TModel : class
        {
            RegisterTrackingObject(wrapper);
        }        

        private void RegisterTrackingObject(IValidatableTrackingObject trackingObject)
        {
            if (!_trackingObjects.Contains(trackingObject))
            {
                _trackingObjects.Add(trackingObject);
                trackingObject.PropertyChanged += TrackingObjectPropertyChanged;
            }
        }

        private void TrackingObjectPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(IsChanged))
            {
                OnPropertyChanged(nameof(IsChanged));
            }
            else if (e.PropertyName == nameof(IsValid))
            {
                OnPropertyChanged(nameof(IsValid));
            }
        }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}