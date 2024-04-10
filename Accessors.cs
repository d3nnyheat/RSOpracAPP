namespace RSOpracAPP;

public partial class Members
{
    public int ID { get; set; }
    public string Surname { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Phone { get; set; }
    public string Adress { get; set; }
    public int ID_Squad { get; set; }
}
public partial class Catalog
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
}
public partial class Staff
{
    public int ID { get; set; }
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
public partial class Orders
{
    public int ID { get; set; }
    public int ID_Member { get; set; }
    public int ID_Catalog { get; set; }
    public int Amount { get; set; }
}
public partial class Squad
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int ID_Specialization { get; set; }
    public int ID_Staff { get; set; }
}

public partial class Events
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int ID_Type { get; set; }
    public string Description { get; set; }
}

public partial class Laureate
{
    public int ID { get; set; }
    public string Surname { get; set; }
    public string Name { get; set; }
    public int ID_Award { get; set; }
    public int ID_Staff { get; set; }
}