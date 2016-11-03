﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarberShop
{
    public partial class Form1 : Form
    {
        static int NumSeats { get; set; } = 3;
        static SemaphoreSlim BarberReady { get; set; } = new SemaphoreSlim(0);
        static SemaphoreSlim WaitingRoom { get; set; } = new SemaphoreSlim(1); // Current count verkar inte minska
        static SemaphoreSlim CustomerWaiting { get; set; } = new SemaphoreSlim(0);

        static int CustomerId { get; set; } = 0;
        public Form1()
        {
            InitializeComponent();
            label1.Text += $" - There are {NumSeats} seats left.\n";
            var b = new Thread(Barber);
            b.IsBackground = true;
            b.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Thread(() => { Customer(CustomerId++); }).Start();
        }

        void Barber()
        {
            while (true)
            {
                label1.Text += "barber waiting for customer...\n";
                CustomerWaiting.Wait();
                label1.Text += "barber is cutting...\n";

                WaitingRoom.Wait();
                NumSeats++;
                WaitingRoom.Release();

                Thread.Sleep(3000);
                BarberReady.Release();
            }
        }

        void Customer(int id)
        {
            label1.Text += $"customer {id} enters.\n";
            WaitingRoom.Wait();
            label1.Text += $"customer {id} waits; {NumSeats} seats left.\n";
            if (NumSeats > 0)
            {
                NumSeats--;
                CustomerWaiting.Release();
                WaitingRoom.Release();

                BarberReady.Wait();
                label1.Text += $"barber finished cutting customer {id} .\n";

            }
            else
            {
                WaitingRoom.Release();
                label1.Text += $"customer {id} got no hair cut.\n";
            }
        }
    }
}
