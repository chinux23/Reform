using System;

using HarmonyLib;

using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.Localization;


namespace Reform
{
	[HarmonyPatch(typeof(DefaultBuildingTypes), "InitializeAll")]
	internal class BuildingRebalanceOverride
	{
		public static void Postfix(
				ref BuildingType ____buildingFortifications,
				ref BuildingType ____buildingSettlementGarrisonBarracks,
				ref BuildingType ____buildingSettlementTrainingFields,
				ref BuildingType ____buildingSettlementLimeKilns,
				ref BuildingType ____buildingSettlementSiegeWorkshop,
				ref BuildingType ____buildingSettlementMilitiaBarracks,
				ref BuildingType ____buildingSettlementGranary,
				ref BuildingType ____buildingSettlementAquaducts,
				ref BuildingType ____buildingSettlementForum,
				ref BuildingType ____buildingSettlementMarketplace,
				ref BuildingType ____buildingSettlementFairgrounds,
				ref BuildingType ____buildingSettlementOrchard,
				ref BuildingType ____buildingCastleLimeKilns,
				ref BuildingType ____buildingCastleMilitiaBarracks,
				ref BuildingType ____buildingCastleSiegeWorkshop,
				ref BuildingType ____buildingCastleFairgrounds,
				ref BuildingType ____buildingCastleWorkshop,
				ref BuildingType ____buildingCastleCastallansOffice,
				ref BuildingType ____buildingCastleGardens,
				ref BuildingType ____buildingCastleGranary,
				ref BuildingType ____buildingCastleTrainingFields,
				ref BuildingType ____buildingCastleBarracks,
				ref BuildingType ____buildingWall,
				ref BuildingType ____buildingDailyBuildHouse,
				ref BuildingType ____buildingDailyTrainMilitia,
				ref BuildingType ____buildingDailyFestivalsAndGames,
				ref BuildingType ____buildingDailyIrrigation)
		{
			DefaultSettlementFoodModel.FoodStocksUpperLimit = 700;
			FileLog.Log("Rebalance buildings.");

			// City

			____buildingFortifications
					.Initialize(new TextObject("{=CVdK1ax1}Fortifications"),
					new TextObject("{=dIM6xa2O}Better fortifications and higher walls around town, also increases the max garrison limit since it provides more space for the resident troops."),
					new int[] { 10000, 20000, 40000 },
					BuildingLocation.Settlement,
					new Tuple<BuildingEffectEnum, int, int, int>[] {
										new Tuple<BuildingEffectEnum, int, int, int
										>(BuildingEffectEnum.GarrisonCapacity, 50, 100, 200)
					},
					0);

			____buildingSettlementGarrisonBarracks
					.Initialize(new TextObject("{=54vkRuHo}Garrison Barracks"),
					new TextObject("{=DHm1MBsj}Logding for the garrisoned troops. Each level increases garrison capacity of the stronghold."),
					new int[] { 5000, 10000, 20000 },
					BuildingLocation.Settlement,
					new Tuple<BuildingEffectEnum, int, int, int>[] {
										new Tuple<BuildingEffectEnum, int, int, int
										>(BuildingEffectEnum.GarrisonCapacity, 50, 100, 200)
					},
					0);

			____buildingSettlementTrainingFields
					.Initialize(new TextObject("{=BkTiRPT4}Training Fields", null),
					new TextObject("{=otWlERkc}A field for military drills that increase the daily experience gain of all garrisoned units."),
					new int[] { 5000, 10000, 20000 },
					BuildingLocation.Settlement,
					new Tuple<BuildingEffectEnum, int, int, int>[] {
										 new Tuple<BuildingEffectEnum, int, int, int
										 >(BuildingEffectEnum.Experience, 10, 20, 40)
					},
					0);

			____buildingSettlementFairgrounds
					.Initialize(new TextObject("{=ixHqTrX5}Fairgrounds", null),
					new TextObject("{=0B91pZ2R}A permanent space that hosts fairs. Citizens can gather, drink dance and socialize,  increasing the daily morale of the settlement."),
					new int[] { 5000, 10000, 20000 },
					BuildingLocation.Settlement,
					new Tuple<BuildingEffectEnum, int, int, int>[] {
										 new Tuple<BuildingEffectEnum, int, int, int
										 >(BuildingEffectEnum.Loyalty, 1, 2, 4)
					},
					0);

			____buildingSettlementMarketplace
					.Initialize(new TextObject("{=zLdXCpne}Marketplace", null),
					new TextObject("{=Z9LWA6A3}Scheduled market days lure folks from surrounding villages to the settlement. Goods are sold for lumpful coins and of course the local ruler takes a handsome cut. Increases wealth and tax yield of the settlement."),
					new int[] { 5000, 10000, 20000 },
					BuildingLocation.Settlement,
					new Tuple<BuildingEffectEnum, int, int, int>[] {
										 new Tuple<BuildingEffectEnum, int, int, int
										 >(BuildingEffectEnum.Tax, 25, 50, 100)
					},
					0);

			____buildingSettlementAquaducts
					.Initialize(new TextObject("{=f5jHMbOq}Aquaducts", null),
					new TextObject("{=UojHRjdG}Access to clean water provides room for growth with healthy citizens and a clean infrastructure. Increases daily Prosperity change."),
					new int[] { 5000, 10000, 20000 },
					 BuildingLocation.Settlement,
					 new Tuple<BuildingEffectEnum, int, int, int>[] {
										 new Tuple<BuildingEffectEnum, int, int, int
										 >(BuildingEffectEnum.Prosperity, 1, 2, 3),
										 new Tuple<BuildingEffectEnum, int, int, int
										 >(BuildingEffectEnum.FoodProduction, 5, 10, 15)
					 },
					 0);

			____buildingSettlementForum
					.Initialize(new TextObject("{=paelEWj1}Forum", null),
					new TextObject("{=wTBtu1t5}An open square in the settlement where people can meet, spend time, and share their ideas. Increases influence of the settlement owner.",
							null),
					new int[] { 5000, 10000, 20000 },
					BuildingLocation.Settlement,
					new Tuple<BuildingEffectEnum, int, int, int>[] {
										 new Tuple<BuildingEffectEnum, int, int, int
										 >(BuildingEffectEnum.Influence, 1, 2, 3)
					},
					0);

			____buildingSettlementGranary
					.Initialize(new TextObject("{=PstO2f5I}Granary", null),
					new TextObject("{=aK23T43P}Keeps stockpiles of food so that the settlement has more food supply. Each level increases the local food supply.",
							null),
					new int[] { 5000, 10000, 20000 },
					BuildingLocation.Settlement,
					new Tuple<BuildingEffectEnum, int, int, int>[] {
										 new Tuple<BuildingEffectEnum, int, int, int
										 >(BuildingEffectEnum.Foodstock, 250, 600, 1050)
					},
					0);

			____buildingSettlementMilitiaBarracks
					.Initialize(new TextObject("{=l91xAgmU}Militia Barracks", null),
					new TextObject("{=RliyRJKl}Provides battle training for citizens and recruit them into militia. Increases daily militia recruitment.",
							null),
					new int[] { 5000, 10000, 20000 },
					BuildingLocation.Settlement,
					new Tuple<BuildingEffectEnum, int, int, int>[] {
										 new Tuple<BuildingEffectEnum, int, int, int
										 >(BuildingEffectEnum.Militia, 2, 4, 6)
					},
					0);

			____buildingSettlementSiegeWorkshop
					.Initialize(new TextObject("{=9Bnwttn6}Siege Workshop", null),
					new TextObject("{=MharAceZ}A workshop dedicated to sieges. Contains tools and materials to repair walls, build and repair siege engines.",
							null),
					new int[] { 5000, 10000, 20000 },
					BuildingLocation.Settlement,
					new Tuple<BuildingEffectEnum, int, int, int>[] {
						new Tuple<BuildingEffectEnum, int, int, int>(BuildingEffectEnum.WallRepairSpeed, 12, 25, 50),
						new Tuple<BuildingEffectEnum, int, int, int>(BuildingEffectEnum.SiegeEngineSpeed, 0, 25, 50)
					},
					0);

			____buildingSettlementLimeKilns
					.Initialize(new TextObject("{=VawDQKLl}Lime Kilns", null),
					new TextObject("{=ac8PkfhG}Lime kilns are kilns to burn lime to produce the form of lime called quicklime which is used to enrich the soil. Increases farm production output",
							null),
					new int[] { 5000, 10000, 20000 },
					BuildingLocation.Settlement,
					new Tuple<BuildingEffectEnum, int, int, int>[] {
						new Tuple<BuildingEffectEnum, int, int, int>(BuildingEffectEnum.FoodProduction, 5, 10, 20),
						new Tuple<BuildingEffectEnum, int, int, int>(BuildingEffectEnum.VillageDevelopmentDaily, 20, 40, 70),
					},
					0);

			____buildingSettlementOrchard
				.Initialize(new TextObject("{=VawDQKLl}Lime Kilns", null),
				new TextObject("{=ac8PkfhG}Lime kilns are kilns to burn lime to produce the form of lime called quicklime which is used to enrich the soil. Increases farm production output",
					null),
				new int[] { 5000, 10000, 20000 },
				BuildingLocation.Settlement,
				new Tuple<BuildingEffectEnum, int, int, int>[] {
						new Tuple<BuildingEffectEnum, int, int, int>(BuildingEffectEnum.FoodProduction, 10, 20, 30),
				},
				0);

			// Castle

			____buildingWall
					.Initialize(new TextObject("{=6pNrNj93}Wall", null),
					new TextObject("{=dIM6xa2O}Better fortifications and higher walls around town, also increases the max garrison limit since it provides more space for the resident troops.",
							null),
					new int[] { 5000, 10000, 20000 },
					BuildingLocation.Castle,
					new Tuple<BuildingEffectEnum, int, int, int>[] {
										 new Tuple<BuildingEffectEnum, int, int, int
										 >(BuildingEffectEnum.GarrisonCapacity, 25, 50, 100)
					},
					1);


			____buildingCastleBarracks
					.Initialize(new TextObject("{=x2B0OjhI}Barracks", null),
					new TextObject("{=HJ1is924}Logdings for the garrisoned troops. Increases garrison capacity of the stronghold.",
							null),
					new int[] { 5000, 10000, 20000 },
					 BuildingLocation.Castle,
					 new Tuple<BuildingEffectEnum, int, int, int>[] {
										 new Tuple<BuildingEffectEnum, int, int, int
										 >(BuildingEffectEnum.GarrisonCapacity, 50, 75, 100)
					 },
					 0);

			____buildingCastleTrainingFields
					.Initialize(new TextObject("{=BkTiRPT4}Training Fields", null),
					new TextObject("{=otWlERkc}A field for military drills that increase the daily experience gain of all garrisoned units.",
							null),
					new int[] { 5000, 10000, 20000 },
					BuildingLocation.Castle,
					new Tuple<BuildingEffectEnum, int, int, int>[] {
										 new Tuple<BuildingEffectEnum, int, int, int
										 >(BuildingEffectEnum.Experience, 10, 20, 40)
					},
					0);

			____buildingCastleGranary
					.Initialize(new TextObject("{=PstO2f5I}Granary", null),
					new TextObject("{=iazij7fO}Keeps stockpiles of food so that the settlement has more food supply. Increases the local food supply.",
							null),
					new int[] { 5000, 10000, 20000 },
					BuildingLocation.Castle,
					new Tuple<BuildingEffectEnum, int, int, int>[] {
										 new Tuple<BuildingEffectEnum, int, int, int
										 >(BuildingEffectEnum.Foodstock, 250, 600, 1050)
					},
					0);

			____buildingCastleGardens
					.Initialize(new TextObject("{=yT6XN4Mr}Gardens", null),
					new TextObject("{=ZCLVOXgM}Castles contained fruit trees, bakeries, chicken coups to be used in emergencies. While it is not enough for a full contingency of troops any small amount of fresh foods are a big help while in the sieges.",
							null),
					new int[] { 5000, 10000, 20000 },
					BuildingLocation.Castle,
					new Tuple<BuildingEffectEnum, int, int, int>[] {
										 new Tuple<BuildingEffectEnum, int, int, int
										 >(BuildingEffectEnum.FoodProduction, 5, 10, 20)
					},
					0);

			____buildingCastleCastallansOffice
					.Initialize(new TextObject("{=kLNnFMR9}Castallan's Office",
							null),
					new TextObject("{=5RMWpLJA}Provides a warden to the castle who maintains discipline and law so rebellions find it harder to form, a castellan to the castle who is effectively the captain of the militia, a steward to the castle who supervised the castle inhibitants.",
							null),
					new int[] { 5000, 10000, 20000 },
					BuildingLocation.Castle,
					new Tuple<BuildingEffectEnum, int, int, int>[] {
										 new Tuple<BuildingEffectEnum, int, int, int
										 >(BuildingEffectEnum.ReduceMilitia, 50, 50, 50),
										 new Tuple<BuildingEffectEnum, int, int, int
										 >(BuildingEffectEnum.Militia, 1, 1, 2)
					},
					0);

			____buildingCastleWorkshop
					.Initialize(new TextObject("{=NbgeKwVr}Workshops", null),
					new TextObject("{=qR9bEE6g}A building which provides the means required for the manufacture or repair of buildings. Improves project development speed. Also stonemasons reinforce the walls.",
							null),
					new int[] { 5000, 10000, 20000 },
					BuildingLocation.Castle,
					new Tuple<BuildingEffectEnum, int, int, int>[] {
										 new Tuple<BuildingEffectEnum, int, int, int
										 >(BuildingEffectEnum.Construction, 1, 2, 3)
					},
					0);

			____buildingCastleFairgrounds
					.Initialize(new TextObject("{=ixHqTrX5}Fairgrounds", null),
					new TextObject("{=QHZeCDJy}A permanent space that hosts fairs. Citizens can gather, drink dance and socialize, increasing the daily morale of the settlement.",
							null),
					new int[] { 5000, 10000, 20000 },
					BuildingLocation.Castle,
					new Tuple<BuildingEffectEnum, int, int, int>[] {
										 new Tuple<BuildingEffectEnum, int, int, int
										 >(BuildingEffectEnum.Loyalty, 1, 2, 4)
					},
					0);

			____buildingCastleSiegeWorkshop
					.Initialize(new TextObject("{=9Bnwttn6}Siege Workshop", null),
					new TextObject("{=MharAceZ}A workshop dedicated to sieges. Contains tools and materials to repair walls, build and repair siege engines.",
							null),
					new int[] { 5000, 10000, 20000 },
					BuildingLocation.Castle,
					new Tuple<BuildingEffectEnum, int, int, int>[] {
										 new Tuple<BuildingEffectEnum, int, int, int
										 >(BuildingEffectEnum.WallRepairSpeed, 50, 50, 50),
										 new Tuple<BuildingEffectEnum, int, int, int
										 >(BuildingEffectEnum.SiegeEngineSpeed, 0, 25, 50)
					},
					0);

			____buildingCastleMilitiaBarracks
					.Initialize(new TextObject("{=l91xAgmU}Militia Barracks", null),
					new TextObject("{=YRrx8bAK}Provides battle training for citizens and recruit them into militia, each level increases daily militia recruitment.",
							null),
					new int[] { 5000, 10000, 20000 },
					BuildingLocation.Castle,
					new Tuple<BuildingEffectEnum, int, int, int>[] {
										 new Tuple<BuildingEffectEnum, int, int, int
										 >(BuildingEffectEnum.Militia, 2, 4, 6)
					},
					0);

			____buildingCastleLimeKilns
					.Initialize(new TextObject("{=VawDQKLl}Lime Kilns", null),
					new TextObject("{=ac8PkfhG}Lime kilns are kilns to burn lime to produce the form of lime called quicklime which is used to enrich the soil. Increases farm production output",
							null),
					new int[] { 5000, 10000, 20000 },
					BuildingLocation.Castle,
					new Tuple<BuildingEffectEnum, int, int, int>[] {
						new Tuple<BuildingEffectEnum, int, int, int>(BuildingEffectEnum.VillageDevelopmentDaily, 5, 10, 15),
						new Tuple<BuildingEffectEnum, int, int, int>(BuildingEffectEnum.FoodProduction, 5, 10, 15)
					},
					0);

			// Daily

			____buildingDailyIrrigation
					.Initialize(new TextObject("{=VawDQKLl}Lime Kilns", null),
					new TextObject("{=ac8PkfhG}Lime kilns are kilns to burn lime to produce the form of lime called quicklime which is used to enrich the soil. Increases farm production output",
						null),
					new int[3],
					BuildingLocation.Daily,
					new Tuple<BuildingEffectEnum, int, int, int>[] {
						new Tuple<BuildingEffectEnum, int, int, int>(BuildingEffectEnum.VillageDevelopmentDaily, 20, 40, 70),
						new Tuple<BuildingEffectEnum, int, int, int>(BuildingEffectEnum.FoodProduction, 10, 20, 30)
					},
					0);
		}
	}
}
