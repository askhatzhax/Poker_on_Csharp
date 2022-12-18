using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        Cards cards = new Cards();
        cards.GetInfo();
        Hand hand = new Hand();
        hand.ShowHand();
        int n,m;
        while (true)
        {
            Console.WriteLine("\n**********************\n ");
            Console.WriteLine(" номер текущей карты в руке =");
            n = Convert.ToInt32(Console.ReadLine())-1;
            Console.WriteLine(" порядковый номер карты в колоде =");
            m = Convert.ToInt32(Console.ReadLine())-1;
            Console.WriteLine("Если хотите еще поменять карт то введите любое число кроме 0\nЕсли хотите завершить обмен карт то введите 0");
            hand.ChangeCard(n, m);
            if (Convert.ToInt32(Console.ReadLine()) == 0)
            {
                break;
            }
        }
        hand.ShowHand();

    }

    class Hand : Cards
    {
        private List<Card> handOfCards = new List<Card>();

        public Hand()
        {
            Random rand = new Random();
            int[] arr=new int[5];
            for (int i = 0; i < arr.Length; i++) {
                int a = rand.Next(0, 52);
                arr[i] = a;
                while (!arr.Contains(a))
                {

                    rand = new Random();
                    a = rand.Next(0, 52);
                }
                arr[i] = a;
            }

            for (int j = 0; j < 5; j++)
            {
                handOfCards.Add(cards[arr[j]]);
             }

        }
        public void ChangeCard(int n, int m)//n- номер текущей карты m - номер новой карты карты
        {
            handOfCards[n] = cards[m];
        }
        public void ShowHand()
        {
            Console.WriteLine("\n****My hand****");
            int i = 1;
            foreach (var a in handOfCards)
            {
                Console.WriteLine("\n number : "+ i+" ");
                i++;
                a.GetCard();
            }
        }
    }   

    class Card
    {
        string rank;
        string suit;
        public Card(string rank, string suit)
        {
            this.rank = rank;
            this.suit = suit;
        }
        public void GetCard()
        {
            if ( this.suit== "\u2665" || this.suit == "\u2666") { Console.ForegroundColor = ConsoleColor.Red; }
            else { Console.ResetColor(); }
            Console.Write(" " + this.rank + " " + this.suit);
        }

    }

    class Cards
    {
        public List<Card> cards = new List<Card>();
        public Cards()
        {
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

            string[] suits = { "\u2660", "\u2665", "\u2666", "\u2663" }; //♠ ♥ ♦ ♣ 
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < ranks.Length; j++)
                {
                    cards.Add(new Card(ranks[j], suits[i]));
                }
            }
        }
        /*
        public void AddCard(Card card)
        {
            cards.Add(card);
        }
        */
        public void GetInfo()
        {
            Console.WriteLine("****Coloda of card****");
            int i = 1;
            foreach (var a in cards)
            {
                Console.WriteLine("\n number : " + i + " ");
                i++;
                a.GetCard();
            }
        }
    }
}