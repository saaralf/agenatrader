//--------------------------------------------------------------
//-- Auskleichkerzen in blau und orange darstellen
//-- copyright Michael Keller
//--------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using AgenaTrader.API;
using AgenaTrader.Custom;
using AgenaTrader.Plugins;
using AgenaTrader.Helper;

namespace AgenaTrader.UserCode
{
	[Category("")] // Define your own category
	[Description("")] // Write a description about your script
	public class AGK : UserIndicator
	{
		protected override void OnInit()
		{
			// Executed once at the beginning
			// Write your own initialization code
			// More Information: https://agenatrader.github.io/AgenaScript-documentation/keywords/#oninit

			IsOverlay = true;
		}

		protected override void OnCalculate()
		{
			// Executed once for every single bar, starting from the first in the chart
			// Write your own bar handling here
			// More Information: https://agenatrader.github.io/AgenaScript-documentation/events/#oncalculate


			//Short Kerze
			if (Open[0] - Close [0] >0) // Ist Short Kerze
			{
				double koerper=(Open[0] - Close [0])*2;
				if (High[0] - Open[0] > koerper )
				{
					if ( Close [0]- Low[0] > koerper )	
						{		 
							BarColor = Color.Orange;
							CandleOutlineColor = Color.Orange;
						}
				}		
			}
			
			// Long Kerze
			if (Close[0] - Open [0] >0) // Ist Long Kerze
			{
				double koerper=(Close[0] - Open [0])*2;
				if (High[0] - Close[0] > koerper )
				{
					if ( Open [0]- Low[0] > koerper )	
						{		 
							BarColor = Color.Blue;
							CandleOutlineColor = Color.Blue;
						}
				}		
			}
			
		}
	}
}
