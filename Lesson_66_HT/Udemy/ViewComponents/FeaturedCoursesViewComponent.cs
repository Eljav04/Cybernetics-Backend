using Microsoft.AspNetCore.Mvc;
using Udemy.DAL;
using Udemy.DAL.Interfaces;
using Udemy.Entity;

namespace Udemy.Components
{
    public class FeaturedCoursesViewComponent : ViewComponent
    {
        private ICourseRepository _courseRepository;
        public FeaturedCoursesViewComponent(ICourseRepository courseRepository) 
        {
            _courseRepository = courseRepository;
        
        }

        public IViewComponentResult Invoke()
        {
            return View(_courseRepository.GetFeaturedCourses());
        }
    }
}
