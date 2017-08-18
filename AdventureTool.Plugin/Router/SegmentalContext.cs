using System;
using AdventureTool.Plugin.Router.Interfaces;

namespace AdventureTool.Plugin.Router
{
    public class SegmentalContext : IRoutingContext
    {
        private readonly IRoutingContext _context;
        private int _currentIndex;

        public SegmentalContext(IRoutingContext ctx)
        {
            _context = ctx;
        }

        public void Next()
        {
            _currentIndex++;
        }

        public Uri Uri => _context.Uri;

        public string Current => _context.Uri.Segments[_currentIndex];
    }
}