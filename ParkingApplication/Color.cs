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
			get => _red; 
            set => _red = GetValidValue(value);
		}

        /// <summary>
        /// Part of the green in the final color 
        /// </summary>
        public int Green
		{
            get => _green;
            set => _green = GetValidValue(value);
        }

        /// <summary>
        /// Part of the blue in the final color 
        /// </summary>
		public int Blue
		{
            get => _blue;
			set => _blue = GetValidValue(value);
        }

        /// <summary>
        /// Opacity of the final color
        /// </summary>
		public int Opacity
		{
			get => _opacity;
			set => _opacity = GetValidValue(value, 0, 100);
		}

        /// <summary>
        /// Constructor without parameters. Getting white color.
        /// </summary>
        public Color()
        {
            _red = 255;
            _green = 255;
            _blue = 255;
            _opacity = 100;
        }

        /// <summary>
        /// Constructor with parameters. Works with default ctor to set default values(else not working).
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
        /// Constructor with parameters. Opacity = 100%. Works with default ctor to set default values(else not working).
        /// </summary>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        public Color(int red, int green, int blue) : this()
        {
            Red = red;
            Green = green;
            Blue = blue;
            _opacity = 100;
        }

        /// <summary>
        /// Validation method for setting color
        /// </summary>
        /// <param name="colorValue">value to set</param>
        /// <param name="minValue">minimal value for setting</param>
        /// <param name="maxValue">maximum value for setting</param>
        /// <returns>checked value for setting</returns>
        private int GetValidValue(int colorValue, int minValue = 0, int maxValue = 255)
        {
            if (colorValue < minValue)
                colorValue = minValue;

            else if (colorValue > maxValue)
                colorValue = maxValue;

            return colorValue;
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
