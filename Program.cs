  using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


class Program
{
         public static async Task Main()
            {
              
                Restaurant obj = new RestaurantMenu();
                Console.WriteLine("Welcome To Restraunt");
                Console.WriteLine(" give your order here");
               
                
obj.Menu();

        try{
            int a = 1;
            while(a==1)
            {
                Console.WriteLine("------------------------");

                Console.WriteLine(" 1 Show menu \n 2 Add item \n 3 Remove \n 4 Show order\n 5 Bill total \n 6 Confirm order ");
 Console.Write("choose from index no. : ");
                int c = Convert.ToInt32(Console.ReadLine());
                 Console.WriteLine("------------------------");
             

                if (c==1)
                {
                    obj.ShowMenu();
                    
                }

                
                else if (c==2)
                {
                     obj.AddItem();
                }

               else if (c==3)
                {
                      obj.RemoveItem();
                }

                else if (c==4)
                {
                    
            Console.WriteLine("------------your order------------");
                      obj.order();
                    Console.Write("your total is : ");

                      obj.Bill();
                }

             else if (c==5)
                {
                    Console.Write("your total is : ");
                      obj.Bill();
                }


                else if (c==6)
                {
                    
            Console.WriteLine("------------your order------------");
                    obj.order();
                    Console.Write("your total is : ");
                    obj.Bill();

             // int o = obj.Bill.ToString();
                
                      await SendNtfyNotification("order" , $"order confirmed!\n your order will be served soon \n your total is  " );

                    a=2 ;

                    Console.WriteLine("\nThankYou for visiting! ");

                }

            
                }
            

                
            }

             catch(Exception ex)   
            {
                Console.WriteLine(ex);
            }

                 
                
            }





         public static async Task SendNtfyNotification(string title, string message)
    {
        using (var httpClient = new HttpClient())
        {
            var topic = "kavyarestaurant"; 
            var url = $"https://ntfy.sh/{topic}";

            var content = new StringContent(message, Encoding.UTF8, "text/plain");

            httpClient.DefaultRequestHeaders.Add("Title", title);

            try
            {
                var response = await httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending notification: " + ex.Message);
            }
        }



          
    }

}

abstract class Restaurant
{
    public abstract void Menu ();
    

    public abstract void Bill();
    public abstract void AddItem();
    public abstract void ShowMenu();
    public abstract void order();


    public abstract void RemoveItem();



}

class MenuItem 
{
     public string Dish {  get;  set;}
    public int Price {  get;  set;}
    public int Index {  get;  set;}

    public MenuItem (int index ,string dish, int price)
    {
        Dish = dish;
        Price = price ;
        Index = index;
    } 
}


class RestaurantMenu : Restaurant
{
        private List<MenuItem> items = new List<MenuItem>();
private List<MenuItem> OrderedItems = new List<MenuItem>();


    public override void Menu ()
    {
       

         items.Add(new MenuItem( 1 ,"Pizza", 400));
         items.Add(new MenuItem( 2 ,"Burger", 300));
         items.Add(new MenuItem( 3 ,"Fries", 300));
         items.Add(new MenuItem( 4 ,"Momos", 300));
         items.Add(new MenuItem( 5 ,"Noodles", 300));
       

    
    }

    public override void ShowMenu()
    {
        Console.WriteLine("\n--- MENU ---");
        foreach (var item in items)
        {
            Console.WriteLine($"{item.Index} - {item.Dish} - ₹{item.Price}");
        }
    }



        
       
    public override void AddItem()
        {
            Console.Write("Select item number to add to your order: ");
      try{      
         int select =Convert.ToInt32(Console.ReadLine() );
         switch(select)
         {
            case 1: 
            OrderedItems.Add(new MenuItem(1 ,"Pizza", 400));
            Console.WriteLine("pizza added ");

           
            break;

             case 2:
            OrderedItems.Add(new MenuItem(2 ,"Burger", 300));
            Console.WriteLine("burger added ");

            break;

            case 3:
            OrderedItems.Add(new MenuItem( 3 ,"Fries", 300));
            Console.WriteLine("fries added");

            break;

            case 4:
            OrderedItems.Add(new MenuItem( 4 ,"Momos", 300 ));
            Console.WriteLine("Momos added");

            break;

             case 5:
            OrderedItems.Add(new MenuItem( 5 ,"Noodles", 300  ));
            Console.WriteLine("Noodles added");

            break;

        
            default:
                Console.WriteLine("Invalid ");
                break;
         }  
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
      }

        }

         public override void RemoveItem()
        {
            Console.Write("Enter item number to remove from your order: ");

            int select =Convert.ToInt32(Console.ReadLine() );
         switch(select)
         {
            case 1: 
              var pizza = OrderedItems.Find(item => item.Index == 1);
            if (pizza != null)
            {
            OrderedItems.Remove(pizza);
            Console.WriteLine("pizza removed ");

            }
           
            break;

             case 2:
              var Burger = OrderedItems.Find(item => item.Index == 2);
            if (Burger != null)
            {
            OrderedItems.Remove(Burger);
            Console.WriteLine("burger removed");
            }
            break;

             case 3:
              var Fries = OrderedItems.Find(item => item.Index == 3);
            if (Fries != null)
            {
            OrderedItems.Remove(Fries);
            Console.WriteLine("fries removed ");

            }
            break;
            
             case 4:
              var Momos = OrderedItems.Find(item => item.Index == 4);
            if (Momos != null)
            {
            OrderedItems.Remove(Momos);
            Console.WriteLine("Momos removed ");

            }
            break;

             case 5:
              var Noodles = OrderedItems.Find(item => item.Index == 5);
            if (Noodles != null)
            {
            OrderedItems.Remove(Noodles);
            Console.WriteLine("Noodles removed ");

            }
            break;

            default:
                Console.WriteLine("Invalid selection.");
                break;
         }  
        }

        
         public override void order()
         {
             foreach (var ordered in OrderedItems)
        {

            Console.WriteLine($"{ordered.Index} - {ordered.Dish} - ₹{ordered.Price}");
        }

         }


          public override void Bill ()
    {
         int total = 0;
        foreach (var ordered in OrderedItems)
        {
               
                total += ordered.Price ;
           
          
        }
        

         Console.WriteLine($"₹{total}");
         
       
       
    }

    }

   
   
    


