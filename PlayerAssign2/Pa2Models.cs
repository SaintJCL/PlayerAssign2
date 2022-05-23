using System;
using Interface;

namespace Pa2.Models
{
	/// <summary>
	/// Base player model used for players & bots
	/// </summary>
	/// 
	public abstract class Player : IPlayer
	{
		private int _level;
		private Guid _id;

		public Player()
		{
			_id = Guid.NewGuid();
			_level = 1;
		}
		public Guid Id { get { return _id; } set { _id = value; } }

		/// <summary>
		/// players can have empty names, bots should not
		/// </summary>
		public virtual string Name { get; set; }

		/// <summary>
		/// regular players start at power 1, bots are based on their level
		/// </summary>
		public virtual int Power { get; set; } = 10;

		/// <summary>
		/// All players start at level 1, bots level increases during the level
		/// </summary>
		public int Level { get { return _level; } set { _level = value; } }

		public abstract void LevelUpDown(int up);

		public void PowerUpDown(int pow)
		{
			Power += pow;
		}
		
	}

	public class Infantry : Player
	{
		/// <summary>
		/// For new player creation
		/// </summary>
		public Infantry() { }
		/// <summary>
		/// for loading players from a file
		/// </summary>
		/// <param name="level"></param>
		/// <param name="id"></param>
		/// <param name="name"></param>
		/// <param name="power"></param>
		public Infantry(int level, Guid id, string name, int power, string email)
		{
			Level = level;
			Id = id;
			Name = name;
			Power = power;
			Email = email;
		}

		public override void LevelUpDown(int up)
		{
			base.Power += up;
		}

		public string Email { get; set; }
		public int Age { get; set; }

		public delegate void Action();

		private Action _act;

		/// <summary>
		/// Here I'm implementing my delegate the
		/// way Jonathan Gollnick. His was way more 
		/// slick and gave me a better idea of how 
		/// I could use them in my game
		/// </summary>
		public Action Act { set => _act = value; }

		public void DoAction()
		{
			if (_act != null)
			{
				_act();
			}
		}

		//public int Age { get { return _age; } set { _age = value; } }

	}

	/// <summary>
	/// This class creates a Bot for a given level
	/// </summary>
	public class Bot : Player
	{
		private readonly string _name;

		/// <summary>
		/// A Bot's power is based on it's level
		/// </summary>
		/// <param name="level"></param>
		public Bot(int level)
		{
			_name = $"Karen-{base.Id.ToString().Substring(0, 5)}";
			Power = level;
		}

		/// <summary>
		/// Bots are automatically given a name based on their Ids
		/// </summary>
		public override string Name { get => _name; }

		/// <summary>
		/// Bots power is based on its level
		/// </summary>
		public override int Power { get; set; }

		/// <summary>
		/// Bots level up based on the level clock.
		/// As the players spend more time in the level, the bots level => power increases
		/// </summary>
		/// <param name="timeOffest"></param>
		public override void LevelUpDown(int timeOffest)
		{
			Level += timeOffest;
		}
	}

}
