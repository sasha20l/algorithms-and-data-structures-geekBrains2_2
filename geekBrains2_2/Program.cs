using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geekBrains2_2
{


        public class Node
        {
            public int Value { get; set; }
            public Node NextNode { get; set; }
            public Node PrevNode { get; set; }
        }

        //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
        public interface ILinkedList
        {
            int GetCount(); // возвращает количество элементов в списке   ***
            void AddNode(int value);  // добавляет новый элемент списка    ***
            void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента ***
            void RemoveNode(int index); // удаляет элемент по порядковому номеру ***
            void RemoveNode(Node node); // удаляет указанный элемент ***
            Node FindNode(int searchValue); // ищет элемент по его значению   ***
        }

    public class LinkedList : ILinkedList
    {

        private int _count = 0;
        private Node _startNode;
        private Node _endNode;

        static void Main(string[] args)
        {
            LinkedList linkedList = new LinkedList(); // Создаем экземпляр класса

            for (int i = 0; i < 10; i++) // Заполняем нодами от 1 до 10
            {
                linkedList.AddNode(i);

            }
            linkedList.AddNodeAfter(new Node { Value = 999 }, 9); // В конце дополняем нодой 999


            Console.WriteLine(WritteNode(5, linkedList));
            Console.WriteLine(WritteNode(1, linkedList));
            Console.WriteLine(WritteNode(999, linkedList));
            Console.WriteLine(WritteNode(9, linkedList));
            Console.WriteLine(WritteNode(3, linkedList)); // Выводим значения нод на экран.


            linkedList.RemoveNode(10); // Удаляем ноду № 10 (Число 999)

            Console.WriteLine();

            Console.WriteLine(WritteNode(5, linkedList));
            Console.WriteLine(WritteNode(1, linkedList));
            Console.WriteLine(WritteNode(999, linkedList));
            Console.WriteLine(WritteNode(9, linkedList));
            Console.WriteLine(WritteNode(3, linkedList)); // Выводим значения нод на экран.

            Console.ReadLine();
        }

        public static string WritteNode(int number, LinkedList list)
        {
            if (list.FindNode(number) == null) return "Такой ноды нету";
            return list.FindNode(number).Value.ToString();
        }
        public void AddNode(int value)
        {
            if(_startNode == null)
            {
                _startNode = new Node
                {
                    Value = value
                };
                _endNode = _startNode;

            }
            _endNode.Value = value;
            var newNode = new Node();
            _endNode.NextNode = newNode;
            newNode.PrevNode = _endNode;
            _endNode = newNode;

            _count++;
        }
        public void AddNodeAfter(Node node, int value)
        {
            Node nodeOfValue = FindNode(value);
            node.NextNode = nodeOfValue.NextNode;
            nodeOfValue.NextNode = node;
            node.PrevNode = nodeOfValue;
            _count++;
        }

        public Node FindNode(int searchValue)
        {
            Node thisNode = null;
            bool flagEndNode = true;

            if (thisNode == null)
            {
                thisNode = _startNode;
            }

            while (flagEndNode)
            {
                if (thisNode.Value == searchValue) return thisNode;
                else if (thisNode == _endNode)
                {
                    flagEndNode = false;   
                }
                else
                {
                    thisNode = thisNode.NextNode;
                }

            }
            return null;
        }

        public int GetCount()
        {
            return _count;
        }

        public void RemoveNode(int index)
        {
            Node thisNode = null;
            Node indexNode = null;
            bool flagEndNode = true;
            int numberNode = 0;

            if (thisNode == null)
            {
                thisNode = _startNode;
            }

            while (flagEndNode)
            {
                if (numberNode == index)
                {
                    RemoveNode(thisNode);
                    flagEndNode = false;
                }
                else if (thisNode == _endNode)
                {
                    flagEndNode = false;
                }
                else
                {
                    thisNode = thisNode.NextNode;
                }
                numberNode++;

            }
            if (indexNode == null) return;
        }

        public void RemoveNode(Node node)
        {
            Node prevNode = node.PrevNode;
            Node NextNode = node.NextNode;
            prevNode.NextNode = node.NextNode;
            NextNode.PrevNode = node.PrevNode;
            _count--;
        }
    }

}
