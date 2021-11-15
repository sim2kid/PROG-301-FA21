using System;
using System.Collections;
using System.Collections.Generic;

namespace MVC_Site.ViewModels
{
    public sealed class Toolbox
    {
        private static readonly Lazy<Toolbox> lazy =
            new Lazy<Toolbox>(() => new Toolbox());
        /// <summary>
        /// The singleton instance of the Toolbox
        /// </summary>
        public static Toolbox Instance { get { return lazy.Value; } }

        /// <summary>
        /// A global coffee view to be used on all pages
        /// </summary>
        public CoffeeView coffeeView { get; private set; }

        private Toolbox() 
        {
            coffeeView = new CoffeeView();
        }
    }
}
