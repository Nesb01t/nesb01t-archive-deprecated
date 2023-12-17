using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using LumosBringers.Models;
using LumosBringers.Service;
using LumosBringers.Test;
using LumosBringers.Utils;

namespace LumosBringers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Main
    {
        private DispatcherTimer _timer;

        public Main()
        {
            // 核心初始化
            InitializeComponent();
            Core.Init();

            TextSpeedModify.Text = "7";
            ListBoxTele.ItemsSource = Core.TeleListHolder.points;

            // UI 时钟初始化
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(Core.UpdateIntervalUi);
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        /// <summary>
        /// Timer 功能主线程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object? sender, EventArgs e)
        {
            UpdatePlayerInfo(); // 更新数据到池 -> UI

            // 尝试改变玩家移速
            PlayerSpyService.ModifySpeed(String2Num.GetFloat(TextSpeedModify.Text));
            // PlayerSpyService.ModifyNoFalling();
        }


        /// <summary>
        /// 角色页面 -> 更新血量数据
        /// </summary>
        private void UpdatePlayerInfo()
        {
            var p = Core.ObjectHolder.GetPlayerObject();

            // player health
            if (p.HpMax != 0)
            {
                BarPlayerHealth.Value = 100.0 * p.HpCurr / p.HpMax;
                LabelPlayerHealth.Content = "" + p.HpCurr + " / " + p.HpMax;
            }
            else
            {
                BarPlayerHealth.Value = 0;
                LabelPlayerHealth.Content = "未知";
            }


            // player mana
            if (p.ManaMax != 0)
            {
                BarPlayerMana.Value = 100.0 * p.ManaCurr / p.ManaMax;
                LabelPlayerMana.Content = "" + p.ManaCurr + " / " + p.ManaMax;
            }
            else
            {
                BarPlayerMana.Value = 0;
                LabelPlayerMana.Content = "未知";
            }


            // player xyz
            LabelPlayerX.Content = "X 坐标 " + p.PosX.ToString("F1");
            LabelPlayerY.Content = "Y 坐标 " + p.PosY.ToString("F1");
            LabelPlayerZ.Content = "Z 坐标 " + p.PosZ.ToString("F1");
            LabelPlayerSpeed.Content = "移动速度 " + p.Speed;
            LabelPlayerMoveFlag.Content = "移动状态 " + p.MovementFlags;
        }

        /// <summary>
        /// 调试页面 -> 刷新
        /// </summary>
        private void UpdateDebugText()
        {
            TextBoxTest.Text = "[Debug] " + DateTime.Now + '\r' + '\r';

            // debugger
            TextBoxTest.Text += ProcessHolderTest.Test() + "\r";
            TextBoxTest.Text += ObjectHolderTest.Test() + "\r";
            TextBoxTest.Text += TeleListHolderTest.Test() + "\r";
        }

        private void ButtonTest_OnClick(object sender, RoutedEventArgs e)
        {
            Core.UpdateProcess();
            UpdateDebugText();
        }

        private void ButtonStopFall_OnClick(object sender, RoutedEventArgs e)
        {
            PlayerSpyService.ModifyNoFalling();
        }

        private void ListBoxTele_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var point = ListBoxTele.SelectedItem as Telepoint;
            TextBoxTest.Text += point + "\r";
            if (point != null)
            {
                PlayerSpyService.Teleport(point);
            }
        }
    }
}