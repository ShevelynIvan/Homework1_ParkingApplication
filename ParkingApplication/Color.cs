namespace ParkingApplication
{
    internal struct Color
    {
		private int _red;
		private int _green;
		private int _blue;
		private int _opacity;

        /// <summary>
        /// Part of the red in the final color 
        /// </summary>
        public int Red
		{
			get { return _red; }
			set 
			{ 
				if (value < 0)
					value = 0;

				else if (value > 255)
                    value = 255;

				_red = value;
			}
		}

        /// <summary>
        /// Part of the green in the final color 
        /// </summary>
        public int Green
		{
			get { return _green; }
			set 
			{
                if (value < 0)
                    value = 0;

                else if (value > 255)
                    value = 255;

                _green = value;
            }
		}

        /// <summary>
        /// Part of the blue in the final color 
        /// </summary>
		public int Blue
		{
			get { return _blue; }
			set 
			{
                if (value < 0)
                    value = 0;

                else if (value > 255)
                    value = 255;

                _blue = value;
            }
		}

        /// <summary>
        /// Opacity of the final color
        /// </summary>
		public int Opacity
		{
			get { return _opacity; }
			set 
			{
                if (value < 0)
                    value = 0;

                else if (value > 100)
                    value = 100;

                _opacity = value;
            }
		}

        /// <summary>
        /// Constructor with parameters. Works with default ctor to set default values.
        /// </summary>
        /// <param name="red">Part of the red in the final color</param>
        /// <param name="green">Part of the green in the final color</param>
        /// <param name="blue">Part of the blue in the final color</param>
        /// <param name="opacity">Opacity of the final color</param>
        public Color(int red, int green, int blue, int opacity) : this()
        {
            Red = red;
			Green = green;
			Blue = blue;
			Opacity = opacity;
        }

        /// <summary>
        /// Overridden ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
			return $"Red: {_red}, Green: {_green}, Blue: {_blue}, Opacity {_opacity}";
        }
    }
}
