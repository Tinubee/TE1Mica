using Cognex.VisionPro.ToolBlock;

namespace TE1.SheetR
{
    public class MainTools : BaseTool
    {
        public MainTools(CogToolBlock tool) : base(tool) { }
        public override Cameras Camera => Cameras.SheetR;
    }

    public class AlignTools : SheetL.AlignTools
    {
        public AlignTools(CogToolBlock tool) : base(tool) { }
        public override Cameras Camera => Cameras.SheetR;
    }

    public class Calculator : SheetL.Calculator
    {
        public Calculator(CogToolBlock tool) : base(tool) { }
        public override Cameras Camera => Cameras.SheetR;
    }

    public class Verification : SheetL.Verification
    {
        public Verification(CogToolBlock tool) : base(tool) { }
        public override Cameras Camera => Cameras.SheetR;
    }
}