using System;
using System.Linq;
using Sudoku.ApplicationLayer.Models;

namespace Sudoku.Client.Wrapper
{
	public partial class GameBoardWrapper : ModelWrapper<GameBoard>
	{	
		public GameBoardWrapper(GameBoard model ) : base (model)
		{
			
		}


		public System.Int32[,] PuzzleArray
		{
			get { return GetValue<System.Int32[,]>(); }
			set { SetValue(value); }
		}
			
		public System.Int32[,] PuzzleArrayOriginalValue => GetOriginalValue<System.Int32[,]>(nameof(PuzzleArray));

		public bool PuzzleArrayIsChanged => GetIsChanged(nameof(PuzzleArray));

		public System.Int32 Cell00
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell00OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell00));

		public bool Cell00IsChanged => GetIsChanged(nameof(Cell00));

		public System.Int32 Cell01
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell01OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell01));

		public bool Cell01IsChanged => GetIsChanged(nameof(Cell01));

		public System.Int32 Cell02
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell02OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell02));

		public bool Cell02IsChanged => GetIsChanged(nameof(Cell02));

		public System.Int32 Cell03
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell03OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell03));

		public bool Cell03IsChanged => GetIsChanged(nameof(Cell03));

		public System.Int32 Cell04
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell04OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell04));

		public bool Cell04IsChanged => GetIsChanged(nameof(Cell04));

		public System.Int32 Cell05
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell05OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell05));

		public bool Cell05IsChanged => GetIsChanged(nameof(Cell05));

		public System.Int32 Cell06
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell06OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell06));

		public bool Cell06IsChanged => GetIsChanged(nameof(Cell06));

		public System.Int32 Cell07
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell07OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell07));

		public bool Cell07IsChanged => GetIsChanged(nameof(Cell07));

		public System.Int32 Cell08
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell08OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell08));

		public bool Cell08IsChanged => GetIsChanged(nameof(Cell08));

		public System.Int32 Cell10
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell10OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell10));

		public bool Cell10IsChanged => GetIsChanged(nameof(Cell10));

		public System.Int32 Cell11
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell11OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell11));

		public bool Cell11IsChanged => GetIsChanged(nameof(Cell11));

		public System.Int32 Cell12
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell12OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell12));

		public bool Cell12IsChanged => GetIsChanged(nameof(Cell12));

		public System.Int32 Cell13
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell13OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell13));

		public bool Cell13IsChanged => GetIsChanged(nameof(Cell13));

		public System.Int32 Cell14
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell14OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell14));

		public bool Cell14IsChanged => GetIsChanged(nameof(Cell14));

		public System.Int32 Cell15
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell15OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell15));

		public bool Cell15IsChanged => GetIsChanged(nameof(Cell15));

		public System.Int32 Cell16
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell16OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell16));

		public bool Cell16IsChanged => GetIsChanged(nameof(Cell16));

		public System.Int32 Cell17
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell17OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell17));

		public bool Cell17IsChanged => GetIsChanged(nameof(Cell17));

		public System.Int32 Cell18
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell18OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell18));

		public bool Cell18IsChanged => GetIsChanged(nameof(Cell18));

		public System.Int32 Cell20
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell20OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell20));

		public bool Cell20IsChanged => GetIsChanged(nameof(Cell20));

		public System.Int32 Cell21
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell21OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell21));

		public bool Cell21IsChanged => GetIsChanged(nameof(Cell21));

		public System.Int32 Cell22
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell22OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell22));

		public bool Cell22IsChanged => GetIsChanged(nameof(Cell22));

		public System.Int32 Cell23
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell23OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell23));

		public bool Cell23IsChanged => GetIsChanged(nameof(Cell23));

		public System.Int32 Cell24
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell24OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell24));

		public bool Cell24IsChanged => GetIsChanged(nameof(Cell24));

		public System.Int32 Cell25
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell25OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell25));

		public bool Cell25IsChanged => GetIsChanged(nameof(Cell25));

		public System.Int32 Cell26
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell26OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell26));

		public bool Cell26IsChanged => GetIsChanged(nameof(Cell26));

		public System.Int32 Cell27
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell27OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell27));

		public bool Cell27IsChanged => GetIsChanged(nameof(Cell27));

		public System.Int32 Cell28
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell28OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell28));

		public bool Cell28IsChanged => GetIsChanged(nameof(Cell28));

		public System.Int32 Cell30
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell30OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell30));

		public bool Cell30IsChanged => GetIsChanged(nameof(Cell30));

		public System.Int32 Cell31
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell31OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell31));

		public bool Cell31IsChanged => GetIsChanged(nameof(Cell31));

		public System.Int32 Cell32
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell32OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell32));

		public bool Cell32IsChanged => GetIsChanged(nameof(Cell32));

		public System.Int32 Cell33
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell33OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell33));

		public bool Cell33IsChanged => GetIsChanged(nameof(Cell33));

		public System.Int32 Cell34
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell34OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell34));

		public bool Cell34IsChanged => GetIsChanged(nameof(Cell34));

		public System.Int32 Cell35
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell35OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell35));

		public bool Cell35IsChanged => GetIsChanged(nameof(Cell35));

		public System.Int32 Cell36
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell36OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell36));

		public bool Cell36IsChanged => GetIsChanged(nameof(Cell36));

		public System.Int32 Cell37
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell37OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell37));

		public bool Cell37IsChanged => GetIsChanged(nameof(Cell37));

		public System.Int32 Cell38
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell38OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell38));

		public bool Cell38IsChanged => GetIsChanged(nameof(Cell38));

		public System.Int32 Cell40
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell40OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell40));

		public bool Cell40IsChanged => GetIsChanged(nameof(Cell40));

		public System.Int32 Cell41
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell41OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell41));

		public bool Cell41IsChanged => GetIsChanged(nameof(Cell41));

		public System.Int32 Cell42
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell42OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell42));

		public bool Cell42IsChanged => GetIsChanged(nameof(Cell42));

		public System.Int32 Cell43
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell43OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell43));

		public bool Cell43IsChanged => GetIsChanged(nameof(Cell43));

		public System.Int32 Cell44
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell44OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell44));

		public bool Cell44IsChanged => GetIsChanged(nameof(Cell44));

		public System.Int32 Cell45
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell45OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell45));

		public bool Cell45IsChanged => GetIsChanged(nameof(Cell45));

		public System.Int32 Cell46
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell46OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell46));

		public bool Cell46IsChanged => GetIsChanged(nameof(Cell46));

		public System.Int32 Cell47
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell47OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell47));

		public bool Cell47IsChanged => GetIsChanged(nameof(Cell47));

		public System.Int32 Cell48
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell48OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell48));

		public bool Cell48IsChanged => GetIsChanged(nameof(Cell48));

		public System.Int32 Cell50
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell50OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell50));

		public bool Cell50IsChanged => GetIsChanged(nameof(Cell50));

		public System.Int32 Cell51
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell51OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell51));

		public bool Cell51IsChanged => GetIsChanged(nameof(Cell51));

		public System.Int32 Cell52
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell52OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell52));

		public bool Cell52IsChanged => GetIsChanged(nameof(Cell52));

		public System.Int32 Cell53
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell53OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell53));

		public bool Cell53IsChanged => GetIsChanged(nameof(Cell53));

		public System.Int32 Cell54
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell54OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell54));

		public bool Cell54IsChanged => GetIsChanged(nameof(Cell54));

		public System.Int32 Cell55
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell55OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell55));

		public bool Cell55IsChanged => GetIsChanged(nameof(Cell55));

		public System.Int32 Cell56
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell56OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell56));

		public bool Cell56IsChanged => GetIsChanged(nameof(Cell56));

		public System.Int32 Cell57
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell57OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell57));

		public bool Cell57IsChanged => GetIsChanged(nameof(Cell57));

		public System.Int32 Cell58
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell58OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell58));

		public bool Cell58IsChanged => GetIsChanged(nameof(Cell58));

		public System.Int32 Cell60
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell60OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell60));

		public bool Cell60IsChanged => GetIsChanged(nameof(Cell60));

		public System.Int32 Cell61
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell61OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell61));

		public bool Cell61IsChanged => GetIsChanged(nameof(Cell61));

		public System.Int32 Cell62
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell62OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell62));

		public bool Cell62IsChanged => GetIsChanged(nameof(Cell62));

		public System.Int32 Cell63
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell63OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell63));

		public bool Cell63IsChanged => GetIsChanged(nameof(Cell63));

		public System.Int32 Cell64
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell64OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell64));

		public bool Cell64IsChanged => GetIsChanged(nameof(Cell64));

		public System.Int32 Cell65
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell65OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell65));

		public bool Cell65IsChanged => GetIsChanged(nameof(Cell65));

		public System.Int32 Cell66
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell66OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell66));

		public bool Cell66IsChanged => GetIsChanged(nameof(Cell66));

		public System.Int32 Cell67
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell67OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell67));

		public bool Cell67IsChanged => GetIsChanged(nameof(Cell67));

		public System.Int32 Cell68
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell68OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell68));

		public bool Cell68IsChanged => GetIsChanged(nameof(Cell68));

		public System.Int32 Cell70
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell70OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell70));

		public bool Cell70IsChanged => GetIsChanged(nameof(Cell70));

		public System.Int32 Cell71
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell71OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell71));

		public bool Cell71IsChanged => GetIsChanged(nameof(Cell71));

		public System.Int32 Cell72
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell72OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell72));

		public bool Cell72IsChanged => GetIsChanged(nameof(Cell72));

		public System.Int32 Cell73
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell73OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell73));

		public bool Cell73IsChanged => GetIsChanged(nameof(Cell73));

		public System.Int32 Cell74
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell74OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell74));

		public bool Cell74IsChanged => GetIsChanged(nameof(Cell74));

		public System.Int32 Cell75
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell75OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell75));

		public bool Cell75IsChanged => GetIsChanged(nameof(Cell75));

		public System.Int32 Cell76
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell76OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell76));

		public bool Cell76IsChanged => GetIsChanged(nameof(Cell76));

		public System.Int32 Cell77
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell77OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell77));

		public bool Cell77IsChanged => GetIsChanged(nameof(Cell77));

		public System.Int32 Cell78
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell78OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell78));

		public bool Cell78IsChanged => GetIsChanged(nameof(Cell78));

		public System.Int32 Cell80
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell80OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell80));

		public bool Cell80IsChanged => GetIsChanged(nameof(Cell80));

		public System.Int32 Cell81
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell81OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell81));

		public bool Cell81IsChanged => GetIsChanged(nameof(Cell81));

		public System.Int32 Cell82
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell82OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell82));

		public bool Cell82IsChanged => GetIsChanged(nameof(Cell82));

		public System.Int32 Cell83
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell83OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell83));

		public bool Cell83IsChanged => GetIsChanged(nameof(Cell83));

		public System.Int32 Cell84
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell84OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell84));

		public bool Cell84IsChanged => GetIsChanged(nameof(Cell84));

		public System.Int32 Cell85
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell85OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell85));

		public bool Cell85IsChanged => GetIsChanged(nameof(Cell85));

		public System.Int32 Cell86
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell86OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell86));

		public bool Cell86IsChanged => GetIsChanged(nameof(Cell86));

		public System.Int32 Cell87
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell87OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell87));

		public bool Cell87IsChanged => GetIsChanged(nameof(Cell87));

		public System.Int32 Cell88
		{
			get { return GetValue<System.Int32>(); }
			set { SetValue(value); }
		}
			
		public System.Int32 Cell88OriginalValue => GetOriginalValue<System.Int32>(nameof(Cell88));

		public bool Cell88IsChanged => GetIsChanged(nameof(Cell88));

		public PuzzleManagement.Core.Enums.ObjectState State
		{
			get { return GetValue<PuzzleManagement.Core.Enums.ObjectState>(); }
			set { SetValue(value); }
		}
			
		public PuzzleManagement.Core.Enums.ObjectState StateOriginalValue => GetOriginalValue<PuzzleManagement.Core.Enums.ObjectState>(nameof(State));

		public bool StateIsChanged => GetIsChanged(nameof(State));
	}	
}
