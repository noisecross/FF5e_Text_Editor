using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF5e_Text_Editor
{
    internal class AdressingConfiguration
    {
        public bool EnableRPGeFixes = true;  //Only set to true with RPGe versions of the game
        public bool SpeechPtrs      = true;  //Set to false to read offsets instead

        public int Font1BPP_Add0 = 0x03EB00;
        public int Font1BPP_Add1 = 0x203724; //Poem font
        public int Font1BPP_Size = 0x12C0;
        public int Font1BPP_Siz1 = 0x1380;   //Poem font

        public int Font2BPP_Addr = 0x11F000;
        public int Font2BPP_Size = 0x1000;

        public int FontDama_Addr = 0x149E20;
        public int FontDama_Size = 0x0180;

        public int FontOther_Addr = 0x00D380;
        public int FontOther_Size = 0x0600;

        public int F1BPPWid_Add0 = 0x203225;
        public int F1BPPWid_Add1 = 0x203325;

        public int Misc_DefenseAdd  = 0x203103;
        public int Misc_DefenseSize = 10;
        public int Misc_DefAdd      = 0x20310E;
        public int Misc_DefSize     = 4;
        public int Misc_EqpAdd      = 0x203113;
        public int Misc_EqpSize     = 4;
        public int Misc_EmptyAdd    = 0x203118;
        public int Misc_EmptySize   = 5;
        public int Misc_MasterAdd   = 0x00EA6C;
        public int Misc_MasterSize  = 7;
        public int Misc_AnyAdd      = 0x00F7A8;
        public int Misc_AnySize     = 4;
        public int Misc_PauseAdd    = 0x0115C4;
        public int Misc_PauseSize   = 5;
        public int Misc_LvAdd       = 0x00EA74;
        public int Misc_LvSize      = 2;
        public int Misc_LAdd        = 0x00EAF7;
        public int Misc_LSize       = 1;
        public int Misc_UsesMPAdd   = 0x0EFFBC;
        public int Misc_UsesMPSize  = 6;
        public int Misc_HPAdd       = 0x10E181;
        public int Misc_HPSize      = 2;
        public int Misc_MPAdd       = 0x10E189;
        public int Misc_MPSize      = 2;
        public int Misc_EXPAdd      = 0x10E191;
        public int Misc_EXPSize     = 3;
        public int Misc_SellAdd     = 0x00FAA0;
        public int Misc_SellSize    = 3;

        public int Monster_Add  = 0x200050;
        public int Monster_NRec = 384;
        public int Monster_RSiz = 10;

        public int MonAttakcs_Add  = 0x273700;
        public int MonAttakcs_NRec = 64;
        public int MonAttakcs_RSiz = 16;

        public int SkillsM01_Add  = 0x111C80;
        public int SkillsM01_RSiz = 6;
        public int SkillsM01_NRec = 87;
        public int SkillsM02_Add  = 0x270F90;
        public int SkillsM02_RSiz = 12;
        public int SkillsM02_NRec = 169;
        public int SkillsMBl_Add  = 0x11200D;
        public int SkillsMBl_RSiz = 9;
        public int SkillsMBl_NRec = 30;
        public int SkillsMSo_Add  = 0x111E8A;
        public int SkillsMSo_RSiz = 9;
        public int SkillsMSo_NRec = 8;

        public int SkillsB01_Add  = 0x270900;
        public int SkillsB01_RSiz = 16;
        public int SkillsB01_NRec = 105;
        public int SkillsB02_Add  = 0x271780;
        public int SkillsB02_RSiz = 24;
        public int SkillsB02_NRec = 169;

        public int Commands_Add    = 0x201150;
        public int Commands_NRec   = 95;
        public int Commands_RSiz   = 7;
        public int AbilitiesM_Add  = 0x116200;
        public int AbilitiesM_NRec = 33;
        public int AbilitiesM_RSiz = 8;
        public int AbilitiesB_Add  = 0x277060;
        public int AbilitiesB_NRec = 33;
        public int AbilitiesB_RSiz = 24;

        public int ItemsM_Add  = 0x111380;
        public int ItemsM_NRec = 256;
        public int ItemsM_RSiz = 9;
        public int ItemsR_Add  = 0x273568;
        public int ItemsR_NRec = 24;
        public int ItemsR_RSiz = 13;
        public int ItemsB_Add  = 0x275860;
        public int ItemsB_NRec = 256;
        public int ItemsB_RSiz = 24;

        public int Characters_Add  = 0x115500;
        public int Characters_NRec = 5;
        public int Characters_RSiz = 6;
        public int Jobs_Add        = 0x115600;
        public int Jobs_NRec       = 22;
        public int Jobs_RSiz       = 8;

        public int ConceptsBatR_Add = 0x275800;
        public int ConceptsBatR_NRec = 5;
        public int ConceptsBatR_RSiz = 17;
        public int ConceptsShop_Add = 0x112D00;
        public int ConceptsShop_NRec = 8;
        public int ConceptsShop_RSiz = 8;
        public int ConceptsSMisc_Add = 0x1128B6;
        public int ConceptsMisc_NRec = 24;
        public int ConceptsMisc_RSiz = 8;


        public int Speech_OffAdd = 0x2013F0; //Location of the offsets (or pointers) to each record
        public int Speech_Add    = 0x210000; //Location of the records
        public int Speech_IniOff = 0x000000; //First offset to the table
        public int Speech_NRec   = 2160;     //Number of records
        public int Speech_AvailB = 0x050000; //Total space available to allocate records

        public int PoemOfLight_Add    = 0x2773A0;
        public int PoemOfLight_AvailB = 1416;     //Total space available to allocate records

        public int BatSpeech_OffAdd = 0x10F000;
        public int BatSpeech_Add    = 0x270000;
        public int BatSpeech_IniOff = 0x003B00; //First offset to the table
        public int BatSpeech_NRec   = 234;
        public int BatSpeech_AvailB = 5632;

        public int BatMessages_OffAdd = 0x1139A9;
        public int BatMessages_Add    = 0x270000;
        public int BatMessages_IniOff = 0x002760; //First offset to the table
        public int BatMessages_NRec   = 81;
        public int BatMessages_AvailB = 1646;

        public int ItemDesc_OffAdd = 0x114000;
        public int ItemDesc_Add    = 0x110000;
        public int ItemDesc_IniOff = 0x004100; //First offset to the table
        public int ItemDes2_OffAdd = 0x275100; //If this is 0, ignore import
        public int ItemDes2_Add    = 0x270000;
        public int ItemDes2_IniOff = 0x005200; //First offset to the table
        public int ItemDesc_NRec   = 128;
        public int ItemDesc_AvailB = 1470;

        public int JobDesc_OffAdd = 0x117140;
        public int JobDesc_Add    = 0x110000;
        public int JobDesc_IniOff = 0x00724A; //First offset to the table
        public int JobDesc_NRec   = 133;
        public int JobDesc_AvailB = 3414;

        public int Locations_OffAdd = 0x107000;
        public int Locations_Add    = 0x270000;
        public int Locations_IniOff = 0x000000; //First offset to the table
        public int Locations_NRec   = 164;
        public int Locations_AvailB = 2304;

        public int ConceptsV_OffAdd = 0x00F987;
        public int ConceptsV_Add    = 0x270000;
        public int ConceptsV_IniOff = 0x002F00; //First offset to the table
        public int ConceptsV_NRec   = 139;
        public int ConceptsV_AvailB = 1632;

        public int Credits_Add    = 0x037B92;
        public int Credits_AvailB = 0x2B7;

        public int Staff_Add    = 0x03362B;
        public int Staff_AvailB = 0x20F;

        public int StaffFont_Add    = 0x0333F6;
        public int StaffFont_AvailB = 0x0235;

        public int Dragon4bpp_Add    = 0x032D22;
        public int Dragon4bpp_SizeB  = 0x001200;
        public int Dragon4bpp_AvailB = 0x05FD;

        public int TheEnd4bpp_Add    = 0x10E4CB;
        public int TheEnd4bpp_SizeB  = 0x001000;
        public int TheEnd4bpp_AvailB = 0x071A;
    }
}
