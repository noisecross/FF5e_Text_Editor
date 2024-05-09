using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF5e_Text_Editor
{
    internal class AdressingConfiguration
    {
        public bool EnableRPGeFixes; //Only set to true with RPGe versions of the game
        public bool SpeechPtrs;      //Set to false to read offsets instead

        public int Font1BPP_Add0;
        public int Font1BPP_Add1; //Poem font
        public int Font1BPP_Size;
        public int Font1BPP_Siz1; //Poem font

        public int Font2BPP_Addr;
        public int Font2BPP_Size;

        public int FontDama_Addr;
        public int FontDama_Size;

        public int FontOther_Addr;
        public int FontOther_Size;

        public int F1BPPWid_Add0;
        public int F1BPPWid_Add1;

        public int Misc_DefenseAdd;
        public int Misc_DefenseSize;
        public int Misc_DefAdd;
        public int Misc_DefSize;
        public int Misc_EqpAdd;
        public int Misc_EqpSize;
        public int Misc_EmptyAdd;
        public int Misc_EmptySize;
        public int Misc_MasterAdd;
        public int Misc_MasterSize;
        public int Misc_AnyAdd;
        public int Misc_AnySize;
        public int Misc_PauseAdd;
        public int Misc_PauseSize;
        public int Misc_LvAdd;
        public int Misc_LvSize;
        public int Misc_LAdd;
        public int Misc_LSize;
        public int Misc_UsesMPAdd;
        public int Misc_UsesMPSize;
        public int Misc_HPAdd;
        public int Misc_HPSize;
        public int Misc_MPAdd;
        public int Misc_MPSize;
        public int Misc_EXPAdd;
        public int Misc_EXPSize;
        public int Misc_SellAdd;
        public int Misc_SellSize;

        public int Monster_Add;
        public int Monster_NRec;
        public int Monster_RSiz;

        public int MonAttakcs_Add;
        public int MonAttakcs_NRec;
        public int MonAttakcs_RSiz;

        public int SkillsM01_Add;
        public int SkillsM01_RSiz;
        public int SkillsM01_NRec;
        public int SkillsM02_Add;
        public int SkillsM02_RSiz;
        public int SkillsM02_NRec;
        public int SkillsMBl_Add;
        public int SkillsMBl_RSiz;
        public int SkillsMBl_NRec;
        public int SkillsMSo_Add;
        public int SkillsMSo_RSiz;
        public int SkillsMSo_NRec;

        public int SkillsB01_Add;
        public int SkillsB01_RSiz;
        public int SkillsB01_NRec;
        public int SkillsB02_Add;
        public int SkillsB02_RSiz;
        public int SkillsB02_NRec;

        public int Commands_Add;
        public int Commands_NRec;
        public int Commands_RSiz;
        public int AbilitiesM_Add;
        public int AbilitiesM_NRec;
        public int AbilitiesM_RSiz;
        public int AbilitiesB_Add;
        public int AbilitiesB_NRec;
        public int AbilitiesB_RSiz;

        public int ItemsM_Add;
        public int ItemsM_NRec;
        public int ItemsM_RSiz;
        public int ItemsR_Add;
        public int ItemsR_NRec;
        public int ItemsR_RSiz;
        public int ItemsB_Add;
        public int ItemsB_NRec;
        public int ItemsB_RSiz;

        public int Characters_Add;
        public int Characters_NRec;
        public int Characters_RSiz;
        public int Jobs_Add;
        public int Jobs_NRec;
        public int Jobs_RSiz;

        public int ConceptsBatR_Add;
        public int ConceptsBatR_NRec;
        public int ConceptsBatR_RSiz;
        public int ConceptsShop_Add;
        public int ConceptsShop_NRec;
        public int ConceptsShop_RSiz;
        public int ConceptsSMisc_Add;
        public int ConceptsMisc_NRec;
        public int ConceptsMisc_RSiz;


        public int Speech_OffAdd; //Location of the offsets (or pointers) to each record
        public int Speech_Add;    //Location of the records
        public int Speech_IniOff; //First offset to the table
        public int Speech_NRec;   //Number of records
        public int Speech_AvailB; //Total space available to allocate records

        public int PoemOfLight_Add;
        public int PoemOfLight_AvailB; //Total space available to allocate records

        public int BatSpeech_OffAdd;
        public int BatSpeech_Add;
        public int BatSpeech_IniOff; //First offset to the table
        public int BatSpeech_NRec;
        public int BatSpeech_AvailB;

        public int BatMessages_OffAdd;
        public int BatMessages_Add;
        public int BatMessages_IniOff; //First offset to the table
        public int BatMessages_NRec;
        public int BatMessages_AvailB;

        public int ItemDesc_OffAdd;
        public int ItemDesc_Add;
        public int ItemDesc_IniOff; //First offset to the table
        public int ItemDes2_OffAdd; //If this is 0, ignore import
        public int ItemDes2_Add;
        public int ItemDes2_IniOff; //First offset to the table
        public int ItemDesc_NRec;
        public int ItemDesc_AvailB;

        public int JobDesc_OffAdd;
        public int JobDesc_Add;
        public int JobDesc_IniOff; //First offset to the table
        public int JobDesc_NRec;
        public int JobDesc_AvailB;

        public int Locations_OffAdd;
        public int Locations_Add;
        public int Locations_IniOff; //First offset to the table
        public int Locations_NRec;
        public int Locations_AvailB;

        public int ConceptsV_OffAdd;
        public int ConceptsV_Add;
        public int ConceptsV_IniOff; //First offset to the table
        public int ConceptsV_NRec;
        public int ConceptsV_AvailB;

        public int Credits_Add;
        public int Credits_AvailB;

        public int Staff_Add;
        public int Staff_AvailB;

        public int StaffFont_Add;
        public int StaffFont_AvailB;

        public int Dragon4bpp_Add;
        public int Dragon4bpp_SizeB;
        public int Dragon4bpp_AvailB;

        public int TheEnd4bpp_Add;
        public int TheEnd4bpp_SizeB;
        public int TheEnd4bpp_AvailB;

        public AdressingConfiguration()
        {
            EnableRPGeFixes = ConfigFile_Manager.GetBoolAppValue("EnableRPGeFixes", true); //Only set to true with RPGe versions of the game
            SpeechPtrs      = ConfigFile_Manager.GetBoolAppValue("SpeechPtrs", true);      //Set to false to read offsets instead

            Font1BPP_Add0 = ConfigFile_Manager.GetIntAppValue("Font1BPP_Add0", 0x03EB00);
            Font1BPP_Add1 = ConfigFile_Manager.GetIntAppValue("Font1BPP_Add1", 0x203724); //Poem font
            Font1BPP_Size = ConfigFile_Manager.GetIntAppValue("Font1BPP_Size", 0x12C0);
            Font1BPP_Siz1 = ConfigFile_Manager.GetIntAppValue("Font1BPP_Siz1", 0x1380);   //Poem font

            Font2BPP_Addr = ConfigFile_Manager.GetIntAppValue("Font2BPP_Addr", 0x11F000);
            Font2BPP_Size = ConfigFile_Manager.GetIntAppValue("Font2BPP_Size", 0x1000);

            FontDama_Addr = ConfigFile_Manager.GetIntAppValue("FontDama_Addr", 0x149E20);
            FontDama_Size = ConfigFile_Manager.GetIntAppValue("FontDama_Size", 0x0180);

            FontOther_Addr = ConfigFile_Manager.GetIntAppValue("FontOther_Addr", 0x00D380);
            FontOther_Size = ConfigFile_Manager.GetIntAppValue("FontOther_Size", 0x0600);

            F1BPPWid_Add0 = ConfigFile_Manager.GetIntAppValue("F1BPPWid_Add0", 0x203225);
            F1BPPWid_Add1 = ConfigFile_Manager.GetIntAppValue("F1BPPWid_Add1", 0x203325);

            Misc_DefenseAdd  = ConfigFile_Manager.GetIntAppValue("Misc_DefenseAdd", 0x203103);
            Misc_DefenseSize = ConfigFile_Manager.GetIntAppValue("Misc_DefenseSize", 10);
            Misc_DefAdd      = ConfigFile_Manager.GetIntAppValue("Misc_DefAdd", 0x20310E);
            Misc_DefSize     = ConfigFile_Manager.GetIntAppValue("Misc_DefSize", 4);
            Misc_EqpAdd      = ConfigFile_Manager.GetIntAppValue("Misc_EqpAdd", 0x203113);
            Misc_EqpSize     = ConfigFile_Manager.GetIntAppValue("Misc_EqpSize", 4);
            Misc_EmptyAdd    = ConfigFile_Manager.GetIntAppValue("Misc_EmptyAdd", 0x203118);
            Misc_EmptySize   = ConfigFile_Manager.GetIntAppValue("Misc_EmptySize", 5);
            Misc_MasterAdd   = ConfigFile_Manager.GetIntAppValue("Misc_MasterAdd", 0x00EA6C);
            Misc_MasterSize  = ConfigFile_Manager.GetIntAppValue("Misc_MasterSize", 7);
            Misc_AnyAdd      = ConfigFile_Manager.GetIntAppValue("Misc_AnyAdd", 0x00F7A8);
            Misc_AnySize     = ConfigFile_Manager.GetIntAppValue("Misc_AnySize", 4);
            Misc_PauseAdd    = ConfigFile_Manager.GetIntAppValue("Misc_PauseAdd", 0x0115C4);
            Misc_PauseSize   = ConfigFile_Manager.GetIntAppValue("Misc_PauseSize", 5);
            Misc_LvAdd       = ConfigFile_Manager.GetIntAppValue("Misc_LvAdd", 0x00EA74);
            Misc_LvSize      = ConfigFile_Manager.GetIntAppValue("Misc_LvSize", 2);
            Misc_LAdd        = ConfigFile_Manager.GetIntAppValue("Misc_LAdd", 0x00EAF7);
            Misc_LSize       = ConfigFile_Manager.GetIntAppValue("Misc_LSize", 1);
            Misc_UsesMPAdd   = ConfigFile_Manager.GetIntAppValue("Misc_UsesMPAdd", 0x0EFFBC);
            Misc_UsesMPSize  = ConfigFile_Manager.GetIntAppValue("Misc_UsesMPSize", 6);
            Misc_HPAdd       = ConfigFile_Manager.GetIntAppValue("Misc_HPAdd", 0x10E181);
            Misc_HPSize      = ConfigFile_Manager.GetIntAppValue("Misc_HPSize", 2);
            Misc_MPAdd       = ConfigFile_Manager.GetIntAppValue("Misc_MPAdd", 0x10E189);
            Misc_MPSize      = ConfigFile_Manager.GetIntAppValue("Misc_MPSize", 2);
            Misc_EXPAdd      = ConfigFile_Manager.GetIntAppValue("Misc_EXPAdd", 0x10E191);
            Misc_EXPSize     = ConfigFile_Manager.GetIntAppValue("Misc_EXPSize", 3);
            Misc_SellAdd     = ConfigFile_Manager.GetIntAppValue("Misc_SellAdd", 0x00FAA0);
            Misc_SellSize    = ConfigFile_Manager.GetIntAppValue("Misc_SellSize", 3);

            Monster_Add  = ConfigFile_Manager.GetIntAppValue("Monster_Add", 0x200050);
            Monster_NRec = ConfigFile_Manager.GetIntAppValue("Monster_NRec", 384);
            Monster_RSiz = ConfigFile_Manager.GetIntAppValue("Monster_RSiz", 10);

            MonAttakcs_Add  = ConfigFile_Manager.GetIntAppValue("MonAttakcs_Add", 0x273700);
            MonAttakcs_NRec = ConfigFile_Manager.GetIntAppValue("MonAttakcs_NRec", 64);
            MonAttakcs_RSiz = ConfigFile_Manager.GetIntAppValue("MonAttakcs_RSiz", 16);

            SkillsM01_Add  = ConfigFile_Manager.GetIntAppValue("SkillsM01_Add", 0x111C80);
            SkillsM01_RSiz = ConfigFile_Manager.GetIntAppValue("SkillsM01_RSiz", 6);
            SkillsM01_NRec = ConfigFile_Manager.GetIntAppValue("SkillsM01_NRec", 87);
            SkillsM02_Add  = ConfigFile_Manager.GetIntAppValue("SkillsM02_Add", 0x270F90);
            SkillsM02_RSiz = ConfigFile_Manager.GetIntAppValue("SkillsM02_RSiz", 12);
            SkillsM02_NRec = ConfigFile_Manager.GetIntAppValue("SkillsM02_NRec", 169);
            SkillsMBl_Add  = ConfigFile_Manager.GetIntAppValue("SkillsMBl_Add", 0x11200D);
            SkillsMBl_RSiz = ConfigFile_Manager.GetIntAppValue("SkillsMBl_RSiz", 9);
            SkillsMBl_NRec = ConfigFile_Manager.GetIntAppValue("SkillsMBl_NRec", 30);
            SkillsMSo_Add  = ConfigFile_Manager.GetIntAppValue("SkillsMSo_Add", 0x111E8A);
            SkillsMSo_RSiz = ConfigFile_Manager.GetIntAppValue("SkillsMSo_RSiz", 9);
            SkillsMSo_NRec = ConfigFile_Manager.GetIntAppValue("SkillsMSo_NRec", 8);

            SkillsB01_Add  = ConfigFile_Manager.GetIntAppValue("SkillsB01_Add", 0x270900);
            SkillsB01_RSiz = ConfigFile_Manager.GetIntAppValue("SkillsB01_RSiz", 16);
            SkillsB01_NRec = ConfigFile_Manager.GetIntAppValue("SkillsB01_NRec", 105);
            SkillsB02_Add  = ConfigFile_Manager.GetIntAppValue("SkillsB02_Add", 0x271780);
            SkillsB02_RSiz = ConfigFile_Manager.GetIntAppValue("SkillsB02_RSiz", 24);
            SkillsB02_NRec = ConfigFile_Manager.GetIntAppValue("SkillsB02_NRec", 169);

            Commands_Add    = ConfigFile_Manager.GetIntAppValue("Commands_Add", 0x201150);
            Commands_NRec   = ConfigFile_Manager.GetIntAppValue("Commands_NRec", 95);
            Commands_RSiz   = ConfigFile_Manager.GetIntAppValue("Commands_RSiz", 7);
            AbilitiesM_Add  = ConfigFile_Manager.GetIntAppValue("AbilitiesM_Add", 0x116200);
            AbilitiesM_NRec = ConfigFile_Manager.GetIntAppValue("AbilitiesM_NRec", 33);
            AbilitiesM_RSiz = ConfigFile_Manager.GetIntAppValue("AbilitiesM_RSiz", 8);
            AbilitiesB_Add  = ConfigFile_Manager.GetIntAppValue("AbilitiesB_Add", 0x277060);
            AbilitiesB_NRec = ConfigFile_Manager.GetIntAppValue("AbilitiesB_NRec", 33);
            AbilitiesB_RSiz = ConfigFile_Manager.GetIntAppValue("AbilitiesB_RSiz", 24);

            ItemsM_Add  = ConfigFile_Manager.GetIntAppValue("ItemsM_Add", 0x111380);
            ItemsM_NRec = ConfigFile_Manager.GetIntAppValue("ItemsM_NRec", 256);
            ItemsM_RSiz = ConfigFile_Manager.GetIntAppValue("ItemsM_RSiz", 9);
            ItemsR_Add  = ConfigFile_Manager.GetIntAppValue("ItemsR_Add", 0x273568);
            ItemsR_NRec = ConfigFile_Manager.GetIntAppValue("ItemsR_NRec", 24);
            ItemsR_RSiz = ConfigFile_Manager.GetIntAppValue("ItemsR_RSiz", 13);
            ItemsB_Add  = ConfigFile_Manager.GetIntAppValue("ItemsB_Add", 0x275860);
            ItemsB_NRec = ConfigFile_Manager.GetIntAppValue("ItemsB_NRec", 256);
            ItemsB_RSiz = ConfigFile_Manager.GetIntAppValue("ItemsB_RSiz", 24);

            Characters_Add  = ConfigFile_Manager.GetIntAppValue("Characters_Add", 0x115500);
            Characters_NRec = ConfigFile_Manager.GetIntAppValue("Characters_NRec", 5);
            Characters_RSiz = ConfigFile_Manager.GetIntAppValue("Characters_RSiz", 6);
            Jobs_Add        = ConfigFile_Manager.GetIntAppValue("Jobs_Add", 0x115600);
            Jobs_NRec       = ConfigFile_Manager.GetIntAppValue("Jobs_NRec", 22);
            Jobs_RSiz       = ConfigFile_Manager.GetIntAppValue("Jobs_RSiz", 8);

            ConceptsBatR_Add  = ConfigFile_Manager.GetIntAppValue("ConceptsBatR_Add", 0x275800);
            ConceptsBatR_NRec = ConfigFile_Manager.GetIntAppValue("ConceptsBatR_NRec", 5);
            ConceptsBatR_RSiz = ConfigFile_Manager.GetIntAppValue("ConceptsBatR_RSiz", 17);
            ConceptsShop_Add  = ConfigFile_Manager.GetIntAppValue("ConceptsShop_Add", 0x112D00);
            ConceptsShop_NRec = ConfigFile_Manager.GetIntAppValue("ConceptsShop_NRec", 8);
            ConceptsShop_RSiz = ConfigFile_Manager.GetIntAppValue("ConceptsShop_RSiz", 8);
            ConceptsSMisc_Add = ConfigFile_Manager.GetIntAppValue("ConceptsSMisc_Add", 0x1128B6);
            ConceptsMisc_NRec = ConfigFile_Manager.GetIntAppValue("ConceptsMisc_NRec", 24);
            ConceptsMisc_RSiz = ConfigFile_Manager.GetIntAppValue("ConceptsMisc_RSiz", 8);


            Speech_OffAdd = ConfigFile_Manager.GetIntAppValue("Speech_OffAdd", 0x2013F0); //Location of the offsets (or pointers) to each record
            Speech_Add    = ConfigFile_Manager.GetIntAppValue("Speech_Add", 0x210000); //Location of the records
            Speech_IniOff = ConfigFile_Manager.GetIntAppValue("Speech_IniOff", 0x000000); //First offset to the table
            Speech_NRec   = ConfigFile_Manager.GetIntAppValue("Speech_NRec", 2160);     //Number of records
            Speech_AvailB = ConfigFile_Manager.GetIntAppValue("Speech_AvailB", 0x050000); //Total space available to allocate records

            PoemOfLight_Add    = ConfigFile_Manager.GetIntAppValue("PoemOfLight_Add", 0x2773A0);
            PoemOfLight_AvailB = ConfigFile_Manager.GetIntAppValue("PoemOfLight_AvailB", 1416);     //Total space available to allocate records

            BatSpeech_OffAdd = ConfigFile_Manager.GetIntAppValue("BatSpeech_OffAdd", 0x10F000);
            BatSpeech_Add    = ConfigFile_Manager.GetIntAppValue("BatSpeech_Add", 0x270000);
            BatSpeech_IniOff = ConfigFile_Manager.GetIntAppValue("BatSpeech_IniOff", 0x003B00); //First offset to the table
            BatSpeech_NRec   = ConfigFile_Manager.GetIntAppValue("BatSpeech_NRec", 234);
            BatSpeech_AvailB = ConfigFile_Manager.GetIntAppValue("BatSpeech_AvailB", 5632);

            BatMessages_OffAdd = ConfigFile_Manager.GetIntAppValue("BatMessages_OffAdd", 0x1139A9);
            BatMessages_Add    = ConfigFile_Manager.GetIntAppValue("BatMessages_Add", 0x270000);
            BatMessages_IniOff = ConfigFile_Manager.GetIntAppValue("BatMessages_IniOff", 0x002760); //First offset to the table
            BatMessages_NRec   = ConfigFile_Manager.GetIntAppValue("BatMessages_NRec", 81);
            BatMessages_AvailB = ConfigFile_Manager.GetIntAppValue("BatMessages_AvailB", 1646);

            ItemDesc_OffAdd = ConfigFile_Manager.GetIntAppValue("ItemDesc_OffAdd", 0x114000);
            ItemDesc_Add    = ConfigFile_Manager.GetIntAppValue("ItemDesc_Add", 0x110000);
            ItemDesc_IniOff = ConfigFile_Manager.GetIntAppValue("ItemDesc_IniOff", 0x004100); //First offset to the table
            ItemDes2_OffAdd = ConfigFile_Manager.GetIntAppValue("ItemDes2_OffAdd", 0x275100); //If this is 0, ignore import
            ItemDes2_Add    = ConfigFile_Manager.GetIntAppValue("ItemDes2_Add", 0x270000);
            ItemDes2_IniOff = ConfigFile_Manager.GetIntAppValue("ItemDes2_IniOff", 0x005200); //First offset to the table
            ItemDesc_NRec   = ConfigFile_Manager.GetIntAppValue("ItemDesc_NRec", 128);
            ItemDesc_AvailB = ConfigFile_Manager.GetIntAppValue("ItemDesc_AvailB", 1470);

            JobDesc_OffAdd = ConfigFile_Manager.GetIntAppValue("JobDesc_OffAdd", 0x117140);
            JobDesc_Add    = ConfigFile_Manager.GetIntAppValue("JobDesc_Add", 0x110000);
            JobDesc_IniOff = ConfigFile_Manager.GetIntAppValue("JobDesc_IniOff", 0x00724A); //First offset to the table
            JobDesc_NRec   = ConfigFile_Manager.GetIntAppValue("JobDesc_NRec", 133);
            JobDesc_AvailB = ConfigFile_Manager.GetIntAppValue("JobDesc_AvailB", 3414);

            Locations_OffAdd = ConfigFile_Manager.GetIntAppValue("Locations_OffAdd", 0x107000);
            Locations_Add    = ConfigFile_Manager.GetIntAppValue("Locations_Add", 0x270000);
            Locations_IniOff = ConfigFile_Manager.GetIntAppValue("Locations_IniOff", 0x000000); //First offset to the table
            Locations_NRec   = ConfigFile_Manager.GetIntAppValue("Locations_NRec", 164);
            Locations_AvailB = ConfigFile_Manager.GetIntAppValue("Locations_AvailB", 2304);

            ConceptsV_OffAdd = ConfigFile_Manager.GetIntAppValue("ConceptsV_OffAdd", 0x00F987);
            ConceptsV_Add    = ConfigFile_Manager.GetIntAppValue("ConceptsV_Add", 0x270000);
            ConceptsV_IniOff = ConfigFile_Manager.GetIntAppValue("ConceptsV_IniOff", 0x002F00); //First offset to the table
            ConceptsV_NRec   = ConfigFile_Manager.GetIntAppValue("ConceptsV_NRec", 139);
            ConceptsV_AvailB = ConfigFile_Manager.GetIntAppValue("ConceptsV_AvailB", 1632);

            Credits_Add    = ConfigFile_Manager.GetIntAppValue("Credits_Add", 0x037B92);
            Credits_AvailB = ConfigFile_Manager.GetIntAppValue("Credits_AvailB", 0x2B7);

            Staff_Add    = ConfigFile_Manager.GetIntAppValue("Staff_Add", 0x03362B);
            Staff_AvailB = ConfigFile_Manager.GetIntAppValue("Staff_AvailB", 0x20F);

            StaffFont_Add    = ConfigFile_Manager.GetIntAppValue("StaffFont_Add", 0x0333F6);
            StaffFont_AvailB = ConfigFile_Manager.GetIntAppValue("StaffFont_AvailB", 0x0235);

            Dragon4bpp_Add    = ConfigFile_Manager.GetIntAppValue("Dragon4bpp_Add", 0x032D22);
            Dragon4bpp_SizeB  = ConfigFile_Manager.GetIntAppValue("Dragon4bpp_SizeB", 0x001200);
            Dragon4bpp_AvailB = ConfigFile_Manager.GetIntAppValue("Dragon4bpp_AvailB", 0x05FD);

            TheEnd4bpp_Add    = ConfigFile_Manager.GetIntAppValue("TheEnd4bpp_Add", 0x10E4CB);
            TheEnd4bpp_SizeB  = ConfigFile_Manager.GetIntAppValue("TheEnd4bpp_SizeB", 0x001000);
            TheEnd4bpp_AvailB = ConfigFile_Manager.GetIntAppValue("TheEnd4bpp_AvailB", 0x071A);
        }
    }
}
