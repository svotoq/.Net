using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labNo_5
{
    public class Session
    {
        protected string name;
        protected int test;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int Test
        {
            get
            {
                return test;
            }
            set
            {
                test = value;
            }
        }
    }
    public class Examen : Session
    {
        public Examen(String Name, int Questions)
        {
            name = Name;
            test = Questions;
        }
    }
    public class Zachet : Session
    {
        public Zachet(String Name, int Questions)
        {
            name = Name;
            test = Questions;
        }
    }
    public class MySession : IEnumerable
    {
        public List<Session> SessionList;

        public MySession(Session[] obj)
        {
            SessionList = new List<Session>();
            foreach (Session soft in obj)
            {
                SessionList.Add(soft);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return SessionList.GetEnumerator();
        }
    }
    public class MySession_Controller : IEnumerable<Session>
    {
        private MySession mySession;
        public MySession_Controller(Session[] session)
        {
            mySession = new MySession(session);
        }
        public void Add(Session session)
        {
            mySession.SessionList.Add(session);
        }

        public void PrintSession()
        {
            foreach (Session session in mySession.SessionList)
                Console.WriteLine(session.Name);
        }

        public void RemoveAt(int index)
        {
            if (mySession.SessionList.Count <= index)
                throw new IndexOutOfRangeException("Error!");
            else
                mySession.SessionList.RemoveAt(index);
        }

        public void QueTest(int count)
        {
            foreach (Session session in mySession.SessionList)
                if (session.Test == count)
                    Console.WriteLine($"Тест с {count} вопросами по предмету: " + session.Name);
        }
        public void Espitanii()
        {
            Console.WriteLine("Количество испытаний в сессии: " + mySession.SessionList.Count);
        }

        public IEnumerator<Session> GetEnumerator()
        {
            return mySession.SessionList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return mySession.SessionList.GetEnumerator();
        }

    }
}
