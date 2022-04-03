using System;
using Microsoft.Win32;

namespace AntiVM_cs
{
    class Program
    {
        static void Main()
        {
            MainMenu();
        }

        private static Random random = new Random();

        private static bool MainMenu()
        {
            Console.Title = "AntiVM-KO_pirik3";
            string title = @"
                 _   ___      ____  __            _  __      _       _     _      ____        _      _             
     /\         | | (_) \    / /  \/  |          | |/ /     (_)     | |   | |    / __ \      | |    (_)            
    /  \   _ __ | |_ _ \ \  / /| \  / |  ______  | ' / _ __  _  __ _| |__ | |_  | |  | |_ __ | |     _ _ __   ___  
   / /\ \ | '_ \| __| | \ \/ / | |\/| | |______| |  < | '_ \| |/ _` | '_ \| __| | |  | | '_ \| |    | | '_ \ / _ \ 
  / ____ \| | | | |_| |  \  /  | |  | |          | . \| | | | | (_| | | | | |_  | |__| | | | | |____| | | | |  __/ 
 /_/    \_\_| |_|\__|_|   \/   |_|  |_|          |_|\_\_| |_|_|\__, |_| |_|\__|  \____/|_| |_|______|_|_| |_|\___| 
                                                                __/ |                                              
                                                               |___/                                               
                                                                                           pirik3 - onlinehile.com
                            ";
            string uyari = " <- PASIF, zaman problemi, yardim etmek isteyen olursa VM ler icin mesaj atabilirsiniz.";
            //Console.WriteLine(title);
            ColoredConsoleWrite(ConsoleColor.Cyan, title, ConsoleColor.Red, "");
            ColoredConsoleWrite(ConsoleColor.White, "[1] VirtualBox      ", ConsoleColor.Red, "");
            ColoredConsoleWrite(ConsoleColor.White, "[2] VMWare          ", ConsoleColor.Red, "");
            ColoredConsoleWrite(ConsoleColor.White, "[3] Qemu            ", ConsoleColor.Red, uyari);
            ColoredConsoleWrite(ConsoleColor.White, "[4] Hyper-V         ", ConsoleColor.Red, uyari);
            ColoredConsoleWrite(ConsoleColor.White, "[5] KVM             ", ConsoleColor.Red, uyari);
            ColoredConsoleWrite(ConsoleColor.White, "[6] Windows Sandbox ", ConsoleColor.Red, uyari);
            Console.Write("\n[*] Islem yapilacak VM?? -> ");

            switch (Console.ReadLine())
            {
                case "1":
                    VirtualBox();
                    return false;
                case "2":
                    VMware();                   

                    return true;
                case "3":
                    Console.Write("\r\n" + uyari);
                    return false;
                case "4":
                    Console.Write("\r\n" + uyari);
                    return false;
                case "5":
                    Console.Write("\r\n" + uyari);
                    return false;
                case "6":
                    Console.Write("\r\n" + uyari);
                    return false;
                default:
                    return true;
            }
        }

        private static void VMware()
        {
            string regedit1 = "HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e968-e325-11ce-bfc1-08002be10318}\\0000\\"; //DriverDesc
            string regedit2 = @"HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\"; //SystemBiosVersion
            string regedit3 = @"HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\BIOS\"; //BIOSVendor , BIOSVersion , SystemManufacturer , SystemProductName , SystemVersion
            string cart = (string)Registry.GetValue(regedit1, "DriverDesc", "");
            Console.SetCursorPosition(0, 11);
            //Console.WriteLine("grafik kart: {0}", cart);
            Console.SetCursorPosition(0, 12);
            ClearCurrentConsoleLine();

            // ilk once vmtools yuklenmesi gerekiyor. Sonra regedit islemleri yapilacak.
            // Mac degistirme eklenmeis gerek. 00:0C virtual machine VMware baslangic mac adresi kontrole takiliyor.

            #region REgedit BIOS editleme.
            Registry.SetValue(regedit1, "DriverDesc", "NVIDIA GeForce GTX " + RandomString(4));
            string[] SystemBiosVersionStrings = { "_ASUS_ - " + RandomString(6), RandomString(6), "American Megatrends - " + RandomString(6) };
            Registry.SetValue(regedit2, "SystemBiosVersion", SystemBiosVersionStrings);
            #endregion
        }

        private static void VirtualBox()
        {
            //
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        private static void ColoredConsoleWrite(ConsoleColor firstColor, string firstText, ConsoleColor secondColor, string secondText)
        {
            Console.ForegroundColor = firstColor;
            Console.Write(firstText);
            Console.ForegroundColor = secondColor;
            Console.WriteLine(secondText);
            Console.ResetColor();
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}

