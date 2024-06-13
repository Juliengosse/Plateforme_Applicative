using Api_Rest.Models;

namespace Api_Rest.Repository
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        Student GetById(int id);
        void Add(Student student);
        void Update(Student student);
        void Delete(int id);
    }


    public interface IGroupRepository
    {
        IEnumerable<Group> GetAll();
        Group GetById(int id);
        void Add(Group group);
        void Update(Group group);
        void Delete(int id);
        Task<int?> GetGroupId(string cycle, string section, string subSection);
    }

    public interface IStudentPresenceRepository
    {
        IEnumerable<StudentPresence> GetAll();
        StudentPresence GetById(int id);
        void Add(StudentPresence studentPresence);
        void Update(StudentPresence studentPresence);
        void Delete(int id);
    }

    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Add(User user);
        void Update(User user);
        void Delete(int id);
        Task<User> GetUserByCredentialsAsync(string username, string password);
    }
}
