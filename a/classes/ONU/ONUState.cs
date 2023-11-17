namespace Arrays.classes.ONU
{
    internal class ONUState : State, IONU
    {
        ONU _onu;
        public ONUState(string Name, ONU Onu) : base(Name)
        {

            _onu = Onu;

        }

    }
}
