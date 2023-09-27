
using Microsoft.Win32;

string path = "HKCU->Software";
char input = ' ';
RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE");
List<string> list = new List<string>();


while (input != 'q' && input != 'Q') 
{
    GetPath();
    Console.WriteLine("Текущая позиция: " + path);
    output();
    input = Console.ReadKey().KeyChar;
    Console.WriteLine();
    switch(input)
    {
        case '1':
            FuncrionOne();
            break;
        case '2':
            FunctioTwo();
            break;
        case '3':
            FunctionThree();
            break;
        case '4':
            FunctionFour();
            break;
        case '5':
            Console.Clear();
            break;
        case 'q':
            break;
    }

}




void output() 
{
    Console.WriteLine("Что вы хотите сделать:\n1-Перейти в подраздел\n2-Вернуться на шаг назад\n3-Посмотреть все элементы\n4-Посмотреть имена и значение Value\n5-Очищение консоли");
}



void FuncrionOne() 
{
    Console.WriteLine("Введите ключ который хотите открыть");
    string keyName = Console.ReadLine();
    if (key.OpenSubKey(keyName) != null) 
    {
        key = key.OpenSubKey(keyName);
        path += "->";
        path += keyName;
        list.Add(keyName);
    } 
    else Console.WriteLine("Данный ключ не существует");
}



void FunctioTwo() 
{
    key = Registry.CurrentUser.OpenSubKey("SOFTWARE");
    try
    {
        list.Remove(list.Last());
    }
    catch (Exception e)
    {

        Console.WriteLine("Нельзя вернуться ниже стартовой категории");
        return;
    }
    //list.Remove(list.Last());
    foreach (var str in list)
        key = key.OpenSubKey(str);
   
}


void FunctionThree() 
{
    foreach (string str in key.GetSubKeyNames()) 
    {
        Console.WriteLine(str);
    }
    
}


void FunctionFour() 
{
    Console.WriteLine("Формат: (Название ключа) - (Значение)");
    foreach (var str in key.GetValueNames()) 
    {
        Console.WriteLine(str + " - " + key.GetValue(str));
    }
}


void GetPath() 
{
    path = "HKCU->Software";
    foreach(var str in list) 
    {
        path += "->";
        path+= str;
    }
}