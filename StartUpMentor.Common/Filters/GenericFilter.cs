using System;

namespace StartUpMentor.Common.Filters
{
	public class GenericFilter
    {
        public string SearchString { get; set; }
        public string SortOrder { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public int DefaultPageSize = 10;

        public GenericFilter(string searchString, int pageNumber, int pageSize)
        {
            try
            {
                SearchString = searchString;
                SetPageNumberAndSize(pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetPageNumberAndSize(int pageNumber = 1, int pageSize = 0)
        {
            PageNumber = (pageNumber > 0) ? pageNumber : 1;
            PageSize = (pageSize > 0 && pageSize < DefaultPageSize) ? pageSize : DefaultPageSize;
        }
    }
}
