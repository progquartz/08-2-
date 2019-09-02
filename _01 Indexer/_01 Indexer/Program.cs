using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Indexer
{
    class MyCache
    {
        // Dictionary: key -> value
        private Dictionary<string, string> cache; // my chache class 는 cache라는 필드를 가지고 있는데 이 캐시 필드는 딕셔너리라는 .net기반 클래스를 사용
                                                  // dictionary는 사전처럼 key를 가지고 value를 찾는데 효율적인 자료구조 클래스이다.
                                                  // string, string은 제너릭 부분을 의미하는데, key도 string, value 도 string 을 의미.

        public MyCache()
        {
            cache = new Dictionary<string, string>();
            // Default Cache values
            cache.Add("Debug", "false"); // default값들이다.
            cache.Add("Logging", "true"); // logging이라는 key와 true라는 값을 추가한다.
        }
        public void Add(string key, string value) // 직접적으로 keyt값과, value값을 입력한다.
        {
            if (!cache.ContainsKey(key))
            {
                cache[key] = value;
            }
            else
            {
                throw new ApplicationException("Key already exists");
            }
        }
        private DateTime cacheExpires
        {
            get { return cacheExpires; }
            set { cacheExpires = value; } // 속성의 경우 파라미터에 받아들이는 부분이 없기에, 이때 속성 대신 인덱서를 쓴다.
                                          // 속성의 경우 파라미터가 없지만, 인덱스에서는 파라미터를 받아낼 수 있다.
                                          // 일반적으로 속성은 클래스 내의 필드에 접근할때 쓰고
        }

        public string this[string key] // 인덱스는 this라고 하는 키워드를 사용하여 임대 인덱스를 의미합니다. 
                                       // 속성은 각자의 이름이 있는 반면에, this만으로 의미한다.
                                       // 인덱스는 ㅋㄹ래스의 컬랙션 데이터를 컬렉션 데이터중 특정 요소에 접근할 수 있게 한다.. 
        {// 인덱서의 기본 골격은 get, set이다.
            get // 아래쪽에 만든 메소드인 get과 set 을 인덱서로 구현.
            {
                if (cache.ContainsKey(key))
                {
                    return cache[key];
                }
                return null;
            }
            set
            {
                if (cache.ContainsKey(key))
                {
                    cache[key] = value;
                }
                else
                {
                    throw new ApplicationException("Key Not fount");
                }
            }
        }
        // cache field의 데이터가 누적되었을떄 이를 가져오는 getmethod 추가.

        public string Get(string key) //
        {
            if (cache.ContainsKey(key))
            {
                return cache[key];
            }
            return null;
        }
        public void Set(string key, string value)
        {
            if (cache.ContainsKey(key))
            {
                cache[key] = value;
            }
            else
            {
                throw new ApplicationException("Key Not fount");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // 인덱서
            MyCache myCache = new MyCache();
            myCache.Add("ItemNum", "1100");
            string dbg = myCache.Get("Debug"); // 데이터를 get하고 set하는데에 메서드를 사용한다.
            myCache.Set("Debug", "false");

            string db = myCache["Debug"]; // 인덱서는 더욱 간결하게 사용할 수 있다!
            myCache["Debug"] = "false";
        }
    }
}
