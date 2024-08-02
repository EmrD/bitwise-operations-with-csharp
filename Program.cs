// Bitwise Operatörler
// & operatörü her iki kısım da 1 ise 1 döner; aksi takdirde 0 döner
// | operatörü herhangi bir bit 1 ise 1 döner; aksi takdirde 0 döner
// ~ operatörü bitleri tersine çevirir
// ^ operatörü iki taraftaki bitler farklı ise 1 döner; aksi takdirde 0 döner

class Program
{
    // Rolleri ve izinleri temsil etmek için bit maskeleri tanımlıyoruz.
    [Flags]
    enum Permissions
    {
        None = 0,   // 0000
        Read = 1,   // 0001
        Write = 2,  // 0010
        Execute = 4 // 0100
    }

    static void Main()
    {
        // Kullanıcıya bazı izinler veriyoruz.
        Permissions userPermissions = Permissions.Read | Permissions.Write;

        // Kullanıcının izinlerini kontrol ediyoruz.
        Console.WriteLine($"User has Read permission: {HasPermission(userPermissions, Permissions.Read)}"); // True
        Console.WriteLine($"User has Write permission: {HasPermission(userPermissions, Permissions.Write)}"); // True
        Console.WriteLine($"User has Execute permission: {HasPermission(userPermissions, Permissions.Execute)}"); // False

        // İzin ekleme işlemi
        userPermissions |= Permissions.Execute;
        Console.WriteLine($"User has Execute permission after adding: {HasPermission(userPermissions, Permissions.Execute)}"); // True

        // İzin kaldırma işlemi
        userPermissions &= ~Permissions.Write;
        Console.WriteLine($"User has Write permission after removing: {HasPermission(userPermissions, Permissions.Write)}"); // False

        // İzinleri yazdırma
        Console.WriteLine($"Current permissions: {userPermissions}");
    }

    // Kullanıcının belirli bir izne sahip olup olmadığını kontrol eden metod
    static bool HasPermission(Permissions userPermissions, Permissions permission)
    {
        return (userPermissions & permission) == permission;
    }
}
