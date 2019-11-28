using System;
namespace SkipListControl
{

    public class Node
    {
        public int data;
        public int level;
        public Node[] forward;

        public Node()
        {
            data = 0;
            level = 0;
            forward = new Node[SkipList.MAXLEVEL];
        }
    }

    public class SkipList
    {
        //int num;
        public Node Head;
        int randomSeed;
        public const int MAXLEVEL = 8;
        public SkipList()
        {
            Head = new Node();
            Head.data = 0;
            Head.level = MAXLEVEL;
            //num = 0;
            randomSeed = 0;
            Head.forward = new Node[MAXLEVEL];
            for (int i = 0; i < MAXLEVEL; i++)
            {
                Head.forward[i] = null;
            }
        }

        public int randL()
        {
            Random ran = new Random(randomSeed + DateTime.Now.Second);
            randomSeed++;
            return ran.Next(0, MAXLEVEL + 1);
        }

        public void insert(int key)
        {
            Node p = new Node();
            Node[] update = new Node[MAXLEVEL];
            int i, newlevel;
            newlevel = randL();
            //cout << newlevel << endl;
            for (i = MAXLEVEL - 1; i >= 0; i--)
            {
                p = Head;
                while ((p.forward[i] != null) && (p.forward[i].data < key))
                {
                    p = p.forward[i];
                }
                update[i] = p;
            }

            Node q = new Node();
            q.data = key;
            q.level = newlevel;
            for (i = 0; i < MAXLEVEL; i++)
            {
                if (i <= newlevel)
                {
                    q.forward[i] = update[i].forward[i];
                    update[i].forward[i] = q;
                }
                else
                {
                    q.forward[i] = null;
                }
            }
            Head.data++;
        }

        public Node search(int key)
        {
            Node p = Head;
            for (int i = MAXLEVEL - 1; i >= 0; i--)
            {
                while ((p.forward[i] != null) && (p.forward[i].data <= key))
                {
                    if (p.forward[i].data == key) return p.forward[i];
                    p = p.forward[i];

                }
            }
            return null;
        }

        public int deleten(int key)
        {
            Node p = new Node();
            p = search(key);

            if (p == null) return 0;
            else
            {
                //Node del = p.forward[0];
                Node[] update = new Node[MAXLEVEL];
                Node t;
                for (int i = MAXLEVEL - 1; i >= 0; i--)
                {
                    t = Head;
                    while ((t.forward[i] != null) && (t.forward[i].data < key))
                    {
                        t = t.forward[i];
                    }
                    update[i] = t;
                }
                for (int i = 0; i < MAXLEVEL; i++)
                {
                    //if (del.forward[i] == null) break;
                    update[i].forward[i] = p.forward[i];
                }
                Head.data--;
                return 1;
            }
        }

        public int empty()
        {
            Node p = Head.forward[0];
            Node m = p;
            Head.data = 0;

            while (m != null)
            {
                m = p.forward[0];
                p = m;
            }
            for (int i = 0; i < MAXLEVEL; i++)
            {
                Head.forward[i] = null;
            }
            return 1;
        }


    }

    
    public class Control
    {
        public SkipList Ss;

        public Control()
        {
            Ss = new SkipList();
        }

        public int insert(int i)
        {
            Ss.insert(i);
            return 0;
        }

        public int delete(int i)
        {
            return Ss.deleten(i);
        }

        public Node search(int i)
        {
            return Ss.search(i);
        }

        public int empty()
        {
            Ss.empty();
            return 0;
        }

        public string display()
        {
            string s = "";
            Node sss = Ss.Head;
            s += sss.data.ToString() + ": ";
            sss = sss.forward[0];
            while (sss != null)
            {
                s += sss.data.ToString() + " ->";
                sss = sss.forward[0];
            }
            s += " NULL";
            return s;
        }
    }
}