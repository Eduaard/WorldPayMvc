﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Threading.Tasks;

namespace WorldPayMvc.Test {
    //Creates an HtmlHelper for unit testing
    class HtmlHelperFactory {
        /// <summary>
        /// Create a new HtmlHelper with a fake context and container
        /// </summary>
        /// <returns>HtmlHelper</returns>
        public static HtmlHelper Create() {
            var vc = new ViewContext() { HttpContext = new FakeHttpContext() };
            var html = new HtmlHelper(vc, new FakeViewDataContainer());
            return html;
        }

        private class FakeHttpContext : HttpContextBase {
            private readonly Dictionary<object, object> items = new Dictionary<object, object>();

            public override IDictionary Items {
                get { return items; }
            }
        }

        private class FakeViewDataContainer : IViewDataContainer {
            private ViewDataDictionary viewData = new ViewDataDictionary();
            public ViewDataDictionary ViewData {
                get { return viewData; }
                set { viewData = value; }
            }
        }
    }
}
