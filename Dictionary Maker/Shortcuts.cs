using System.Windows;
using System.Windows.Input;


namespace Dictionary_Maker
{
    public partial class MainWindow : Window
    {
        public void Shortcuts()
        {
            RoutedCommand deleteWordCmd = new RoutedCommand();
            deleteWordCmd.InputGestures.Add(new KeyGesture(Key.Delete, ModifierKeys.Control));
            CommandBindings.Add(new CommandBinding(deleteWordCmd, btnDeleteWord_Click));

            RoutedCommand changeWordCmd = new RoutedCommand();
            changeWordCmd.InputGestures.Add(new KeyGesture(Key.M, ModifierKeys.Control));
            CommandBindings.Add(new CommandBinding(changeWordCmd, btnChangeWord_Click));

            RoutedCommand newFileOpenCmd = new RoutedCommand();
            newFileOpenCmd.InputGestures.Add(new KeyGesture(Key.N, ModifierKeys.Control));
            CommandBindings.Add(new CommandBinding(newFileOpenCmd, NewFile_Click));

            RoutedCommand openFileCmd = new RoutedCommand();
            openFileCmd.InputGestures.Add(new KeyGesture(Key.O, ModifierKeys.Control));
            CommandBindings.Add(new CommandBinding(openFileCmd, OpenFile_Click));
        }
    }
}
