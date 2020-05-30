using System;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace Reform
{
	[HarmonyPatch(typeof(DefaultItemCategories), "RegisterAll")]
	internal class TradableGoodRebalance
	{
		internal static Dictionary<string, object[]>
		DefaultItemCategoryConfigs(DefaultItemCategories __instance)
		{
			var default_item_categories_properties =
					new Dictionary<string, object[]> {
										// Bonus to food.
										{
												"ItemCategoryGrain",
												new object[] {
                            /*isTradeGood=*/
                            true,
                            /*Demand=*/
                            120,
                            /*LuxuryDemand=*/
                            10,
														ItemCategory.Property.BonusToFoodStores,
                            /*substitute*/
                            null,
                            /*substitute_factor*/
                            0,
                            /*is_animal*/
                            false
												}
										},
										{
												"ItemCategoryFish",
												new object[] {
                            /*isTradeGood=*/
                            true,
                            /*Demand*/
                            120,
                            /*LuxuryDemand*/
                            20,
														ItemCategory.Property.BonusToFoodStores,
                            /*substitute*/
                            GetItemCategory(__instance, "ItemCategoryGrain"),
                            /*substitute_factor*/
                            0.1f,
                            /*is_animal*/
                            false
												}
										},
										{
												"ItemCategoryMeat",
												new object[] {
														true,
														120,
														30,
														ItemCategory.Property.BonusToFoodStores,
														GetItemCategory(__instance, "ItemCategoryGrain"),
														0.1f,
														false
												}
										},
										{
												"ItemCategoryCheese",
												new object[] {
														true,
														25,
														40,
														ItemCategory.Property.BonusToFoodStores,
														GetItemCategory(__instance, "ItemCategoryGrain"),
														0.01f,
														false
												}
										},
										{
												"ItemCategoryButter",
												new object[] {
														true,
														20,
														40,
														ItemCategory.Property.BonusToFoodStores,
														null, /*substitute_factor*/
                            0, /*is_animal*/
                            false
												}
										},
										{
												"ItemCategoryGrape",
												new object[] {
														true,
														5,
														40,
														ItemCategory.Property.BonusToFoodStores,
														GetItemCategory(__instance, "ItemCategoryGrain"),
														0.05f,
														false
												}
										},
										{
												"ItemCategoryOlives",
												new object[] {
														true,
														15,
														30,
														ItemCategory.Property.BonusToFoodStores,
														GetItemCategory(__instance, "ItemCategoryGrain"),
														0.05f,
														false
												}
										},
										{
												"ItemCategoryDateFruit",
												new object[] {
														true,
														8,
														40,
														ItemCategory.Property.BonusToFoodStores,
														GetItemCategory(__instance, "ItemCategoryGrape"),
														0.1f,
														false
												}
										},
										{
												"ItemCategoryOil",
												new object[] {
														true,
														8,
														24,
														ItemCategory.Property.BonusToFoodStores,
														GetItemCategory(__instance, "ItemCategoryButter"),
														0.01f,
														false
												}
										},

										// Bonus to Prosperity
										{
												"ItemCategoryFlax",
												new object[] {
														true,
														7,
														10,
														ItemCategory.Property.BonusToProsperity,
														null,
														0,
														false
												}
										},
										{
												"ItemCategoryLinen",
												new object[] {
														true,
														14,
														20,
														ItemCategory.Property.BonusToProsperity,
														null,
														0,
														false
												}
										},
										{
												"ItemCategoryWool",
												new object[] {
														true,
														10,
														25,
														ItemCategory.Property.BonusToProsperity,
														null,
														0,
														false
												}
										},
										{
												"ItemCategoryCloth",
												new object[] {
														false,
														10,
														20,
														ItemCategory.Property.BonusToProsperity,
														null,
														0,
														false
												}
										},
										{
												"ItemCategoryCotton",
												new object[] {
														true,
														20,
														20,
														ItemCategory.Property.BonusToProsperity,
														null,
														0,
														false
												}
										},
										{
												"ItemCategoryVelvet",
												new object[] {
														true,
														10,
														40,
														ItemCategory.Property.BonusToProsperity,
														null,
														0,
														false
												}
										},
										{
												"ItemCategoryHides",
												new object[] {
														true,
														25,
														50,
														ItemCategory.Property.BonusToProsperity,
														null,
														0,
														false
												}
										},
										{
												"ItemCategoryPottery",
												new object[] {
														true,
														11,
														22,
														ItemCategory.Property.BonusToProsperity,
														null,
														0,
														false
												}
										},
										{
												"ItemCategoryLeather",
												new object[] {
														true,
														8,
														24,
														ItemCategory.Property.BonusToProsperity,
														null,
														0,
														false
												}
										},
										{
												"ItemCategoryFur",
												new object[] {
														true,
														12,
														48,
														ItemCategory.Property.BonusToProsperity,
														null,
														0,
														false
												}
										},
										{
												"ItemCategoryJewelry",
												new object[] {
														true,
														1,
														100,
														ItemCategory.Property.BonusToProsperity,
														null,
														0,
														false
												}
										},

										// Bonus to Production
										{
												"ItemCategoryWood",
												new object[] {
														true,
														17,
														34,
														ItemCategory.Property.BonusToProduction,
														null,
														0,
														false
												}
										},
										{
												"ItemCategoryIron",
												new object[] {
														true,
														6,
														12,
														ItemCategory.Property.BonusToProduction,
														null,
														0,
														false
												}
										},
										{
												"ItemCategoryTools",
												new object[] {
														true,
														35,
														70,
														ItemCategory.Property.BonusToProduction,
														null,
														0,
														false
												}
										},
										// Bonus to Tax
										{
												"ItemCategorySalt",
												new object[] {
														true,
														15,
														15,
														ItemCategory.Property.BonusToTax,
														null,
														0,
														false
												}
										},
										{
												"ItemCategorySilver",
												new object[] {
														true,
														15,
														15,
														ItemCategory.Property.BonusToTax,
														null,
														0,
														false
												}
										},

										// Bonus to Loaylty.
										{
												"ItemCategoryBeer",
												new object[] {
														true,
														36,
														36,
														ItemCategory.Property.BonusToLoyalty,
														null,
														0,
														false
												}
										},
										{
												"ItemCategoryWine",
												new object[] {
														true,
														18,
														18,
														ItemCategory.Property.BonusToLoyalty,
														null,
														0,
														false
												}
										},

										// Is Animal
										{
												"ItemCategorySheep",
												new object[] {
														true,
														10,
														10,
														ItemCategory.Property.BonusToFoodStores,
														null,
														0,
														true
												}
										},
										{
												"ItemCategoryCow",
												new object[] {
														true,
														10,
														10,
														ItemCategory.Property.BonusToFoodStores,
														null,
														0,
														true
												}
										},
										{
												"ItemCategoryHog",
												new object[] {
														true,
														10,
														10,
														ItemCategory.Property.BonusToFoodStores,
														null,
														0,
														true
												}
										},
										{
												"ItemCategoryPackAnimal",
												new object[] {
														true,
														15,
														15,
														ItemCategory.Property.BonusToProsperity,
														null,
														0,
														true
												}
										},
										{
												"ItemCategoryHorse",
												new object[] {
														true,
														20,
														40,
														ItemCategory.Property.BonusToProsperity,
														null,
														0,
														true
												}
										},

										// No effects
										{
												"ItemCategoryClay",
												new object[] {
														true,
														15,
														15,
														ItemCategory.Property.None,
														null,
														0,
														true
												}
										},

						};
			return default_item_categories_properties;
		}

		internal static void RebalanceItems(
				DefaultItemCategories __instance,
				Dictionary<string, object[]> item_categories_config
		)
		{
			foreach (KeyValuePair<string, object[]> entry in item_categories_config) {
				ReconfigureItem(__instance, entry.Key, entry.Value);
			}
		}

		internal static ItemCategory GetItemCategory(DefaultItemCategories __instance, string property_name)
		{
			PropertyInfo property = __instance.GetType().GetProperty(
			property_name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
			if (property == null) { return null; }
			MethodInfo getter = property.GetGetMethod(nonPublic: true);
			ItemCategory item_category = (ItemCategory)getter.Invoke(__instance, null);
			return item_category;
		}

		internal static MethodInfo GetInitializeObjectMethod(ItemCategory item_category)
		{
			MethodInfo magicMethod =
					item_category
							.GetType()
							.GetMethod("InitializeObject",
							BindingFlags.Instance | BindingFlags.Public,
							null,
							new Type[] {
												typeof (bool),
												typeof (int),
												typeof (int),
												typeof (ItemCategory.Property),
												typeof (ItemCategory),
												typeof (float),
												typeof (bool)
							},
							null);
			return magicMethod;
		}

		internal static void ReconfigureItem(
				DefaultItemCategories __instance,
				string item_category_name,
				object[] properties
		)
		{
			ItemCategory item_category = GetItemCategory(__instance, item_category_name);
			if (item_category == null) {
				// FileLog.Log("Unable to find item category: " + item_category_name);
				return;
			}
			MethodInfo method_info = GetInitializeObjectMethod(item_category);
			if (method_info == null) {
				//FileLog.Log("Unable to find `InitializeObject` on item category: " +
				// item_category_name);
				return;
			}
			method_info.Invoke(item_category, properties);
		}

		public static void Postfix(DefaultItemCategories __instance)
		{
			//FileLog.Log("Rebalancing tradable goods.");
			RebalanceItems(__instance, DefaultItemCategoryConfigs(__instance));

			// The following item categories are not modified.
			//categories.Add(DefaultItemCategories.WarHorse.InitializeObject(isTradeGood: true, 50, 100, ItemCategory.Property.BonusToGarrison, null, 0f, isAnimal: true));
			//categories.Add(DefaultItemCategories.Arrows.InitializeObject(isTradeGood: false, 30, 30));
			//categories.Add(DefaultItemCategories.HorseEquipment.InitializeObject(isTradeGood: false, 9, 5));
			//categories.Add(DefaultItemCategories.HorseEquipment2.InitializeObject(isTradeGood: false, 7, 6));
			//categories.Add(DefaultItemCategories.HorseEquipment3.InitializeObject(isTradeGood: false, 5, 7));
			//categories.Add(DefaultItemCategories.HorseEquipment4.InitializeObject(isTradeGood: false, 5, 8));
			//categories.Add(DefaultItemCategories.HorseEquipment5.InitializeObject(isTradeGood: false, 5, 9));
			//categories.Add(DefaultItemCategories.MeleeWeapons1.InitializeObject(isTradeGood: false, 9, 7));
			//categories.Add(DefaultItemCategories.MeleeWeapons2.InitializeObject(isTradeGood: false, 7, 7));
			//categories.Add(DefaultItemCategories.MeleeWeapons3.InitializeObject(isTradeGood: false, 5, 10));
			//categories.Add(DefaultItemCategories.MeleeWeapons4.InitializeObject(isTradeGood: false, 4, 10));
			//categories.Add(DefaultItemCategories.MeleeWeapons5.InitializeObject(isTradeGood: false, 4, 10));
			//categories.Add(DefaultItemCategories.RangedWeapons1.InitializeObject(isTradeGood: false, 9, 7));
			//categories.Add(DefaultItemCategories.RangedWeapons2.InitializeObject(isTradeGood: false, 7, 7));
			//categories.Add(DefaultItemCategories.RangedWeapons3.InitializeObject(isTradeGood: false, 5, 10));
			//categories.Add(DefaultItemCategories.RangedWeapons4.InitializeObject(isTradeGood: false, 4, 10));
			//categories.Add(DefaultItemCategories.RangedWeapons5.InitializeObject(isTradeGood: false, 4, 10));
			//categories.Add(DefaultItemCategories.Shield1.InitializeObject(isTradeGood: false, 9, 7));
			//categories.Add(DefaultItemCategories.Shield2.InitializeObject(isTradeGood: false, 7, 7));
			//categories.Add(DefaultItemCategories.Shield3.InitializeObject(isTradeGood: false, 5, 10));
			//categories.Add(DefaultItemCategories.Shield4.InitializeObject(isTradeGood: false, 4, 10));
			//categories.Add(DefaultItemCategories.Shield5.InitializeObject(isTradeGood: false, 4, 10));
			//categories.Add(DefaultItemCategories.Garment.InitializeObject(isTradeGood: false, 9, 15));
			//categories.Add(DefaultItemCategories.LightArmor.InitializeObject(isTradeGood: false, 7, 16));
			//categories.Add(DefaultItemCategories.MediumArmor.InitializeObject(isTradeGood: false, 5, 17));
			//categories.Add(DefaultItemCategories.HeavyArmor.InitializeObject(isTradeGood: false, 4, 17));
			//categories.Add(DefaultItemCategories.UltraArmor.InitializeObject(isTradeGood: false, 3, 10));
			//categories.Add(DefaultItemCategories.Unassigned.InitializeObject());
		}
	}
}
