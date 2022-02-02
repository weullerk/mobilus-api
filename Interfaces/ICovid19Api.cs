using mobilus_test_api.Model;

namespace mobilus_test_api.Interfaces
{
    public interface ICovid19Api
    {
        public List<Case> getLastSixMonthsCase();
    }
}
