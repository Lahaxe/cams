﻿using System.Collections.Generic;

namespace cams.model.Core
{
    /// <summary>
    /// Defines the Collection with pagination information.
    /// </summary>
    /// <typeparam name="T">Object type.</typeparam>
    public class PagedCollection<T>
    {
        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        public IEnumerable<T> Items { get; set; }

        /// <summary>
        /// Gets or sets the page index.
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// Gets or sets the page size.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the number of items.
        /// </summary>
        public long TotalNumberOfItems { get; set; }

        /// <summary>
        /// Gets or sets the number of pages.
        /// </summary>
        public long TotalNumberOfPages { get; set; }
    }
}