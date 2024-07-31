using System;
using System.Collections.Generic;
using System.Linq;

public class SavingAccount
{
    public double LaiXuat { get; set; }
    public int TienTietKiem { get; set; }
}

public class Program
{
    public static double FindOptimalSavings(List<SavingAccount> accounts, double totalAmount)
    {
        double totalProfit = 0.0;

        // Sắp xếp các khoản tiết kiệm theo lãi suất giảm dần
        accounts.Sort((a, b) => b.LaiXuat.CompareTo(a.LaiXuat));

        // Đầu tư vào các khoản tiết kiệm theo thứ tự lãi suất giảm dần
        foreach (var account in accounts)
        {
            if (totalAmount >= account.TienTietKiem)
            {
                totalProfit += account.TienTietKiem * account.LaiXuat;
                totalAmount -= account.TienTietKiem;
            }
            else
            {
                totalProfit += totalAmount * account.LaiXuat;
                totalAmount = 0;
                break;
            }
        }

        return totalProfit;
    }

    public static void Main()
    {
        // Ví dụ về danh sách các khoản tiết kiệm
        var accounts = new List<SavingAccount>
        {
            new SavingAccount { LaiXuat = 0.05, TienTietKiem = 10000 },
            new SavingAccount { LaiXuat = 0.07, TienTietKiem = 5000 },
            new SavingAccount { LaiXuat = 0.06, TienTietKiem = 8000 },
            new SavingAccount { LaiXuat = 0.08, TienTietKiem = 7000 },
            new SavingAccount { LaiXuat = 0.09, TienTietKiem = 3000 }
        };

        double totalAmount = 20000;
        double totalProfit = FindOptimalSavings(accounts, totalAmount);
        Console.WriteLine("Total profit: {0}",totalProfit);
        Console.ReadKey();
    }
}