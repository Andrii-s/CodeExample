@model Infocom.TruckRegistration.HMI.Models.TechnologMealViewModel
@{
	ViewBag.Title = "Склад шроту силосного типу";
	var bunkers = Model.Bunkers;
}
<script src="~/Scripts/jquery.validate.min.js"></script>
<script src="~/Scripts/jquery.validate.unobtrusive.min.js"></script>
<script src="~/Scripts/jquery-ui-1.10.3.js"></script>
<script src="~/Scripts/jquery.ui.datepicker-uk.js"></script>
<script type="text/javascript">
	$(document).ready(function () {
		$("#DateBegin").datepicker({ dateFormat: 'dd.mm.yy', ShowButtonPanel: "true" });
		$("#DateFinish").datepicker({ dateFormat: 'dd.mm.yy', ShowButtonPanel: "true" });
	});
	function ClassificationFromChanged()
	{
		var productId =document.getElementById("ProductFromId").value;
		var classificationFromId = document.getElementById("ClassificationFromId").value;
		var classificationToId = document.getElementById("ClassificationToId").value;

	   
		var bunkersFrom = @Html.Raw(Json.Encode(Model.BunkersFrom));
		var bunkersTo = @Html.Raw(Json.Encode(Model.BunkersTo));
		var silageFrom = document.getElementById("SilageFromId");
		var silageTo = document.getElementById("SilageToId");
		len=silageFrom.length;
		silageFrom.innerHTML="";
	   
		for (var i in bunkersFrom) 
		{
			if (bunkersFrom[i].ParentId == productId
				&& bunkersFrom[i].ClassificationId == classificationFromId) 
			{
				var option = document.createElement("option");
				option.text = bunkersFrom[i].Name;
				option.value = bunkersFrom[i].Id;
				silageFrom.add(option);
			} 
		}

		var option = document.createElement("option");
		option.text = "Відвантаження з підготовчого відділення";
		option.value = 118;
		silageFrom.add(option);
		var option0 = document.createElement("option");
		option0.text = "Відвантаження з екстракційного цеха";
		option0.value = 121;
		silageFrom.add(option0);
		var option1 = document.createElement("option");
		option1.text = "Прихід при інвентарізації";
		option1.value = 117;
		silageFrom.add(option1);

		len2=silageTo.length;
		silageTo.innerHTML="";
	   
		for (var i in bunkersTo) {
			if ((bunkersTo[i].ParentId == productId 
				&& bunkersTo[i].ClassificationId == classificationToId
				||bunkersTo[i].ParentId ==0 )
				) 
			{
				var option = document.createElement("option");
				option.text = bunkersTo[i].Name;
				option.value = bunkersTo[i].Id;
				silageTo.add(option);
			} 
		}
	}

	function ClassificationToChanged()
	{
		var productId =document.getElementById("ProductFromId").value;
		var classificationToId = document.getElementById("ClassificationToId").value;

		var bunkersTo = @Html.Raw(Json.Encode(Model.BunkersTo));
		var silageTo = document.getElementById("SilageToId");

		len2=silageTo.length;
		silageTo.innerHTML="";
	   
		for (var i in bunkersTo) 
		{
			if (bunkersTo[i].ParentId == productId 
				&& bunkersTo[i].ClassificationId == classificationToId
				||bunkersTo[i].ParentId ==0 )
				
			{
				var option = document.createElement("option");
				option.text = bunkersTo[i].Name;
				option.value = bunkersTo[i].Id;
				silageTo.add(option);
			} 
		}
	   
		var option = document.createElement("option");
		option.text = "Списання при інвентаризації";
		option.value = 115;
		silageTo.add(option);
	}

	function productChanged()
	{
		var productId =document.getElementById("ProductFromId").value;
		var classificationFromId = document.getElementById("ClassificationFromId").value;
		var classificationToId = document.getElementById("ClassificationToId").value;

		var classificationsFrom = document.getElementById("ClassificationFromId");
		var classificationsTo = document.getElementById("ClassificationFromId");

		var bunkersFrom = @Html.Raw(Json.Encode(Model.BunkersFrom));
		var bunkersTo = @Html.Raw(Json.Encode(Model.BunkersTo));
		var silageFrom = document.getElementById("SilageFromId");
		var silageTo = document.getElementById("SilageToId");
		len=silageFrom.length;
		silageFrom.innerHTML="";
	   
		for (var i in bunkersFrom) 
		{
			if (bunkersFrom[i].ParentId == productId
				&& bunkersFrom[i].ClassificationId == classificationFromId) 
			{
				var option = document.createElement("option");
				option.text = bunkersFrom[i].Name;
				option.value = bunkersFrom[i].Id;
				silageFrom.add(option);
			} 
		}

		var option = document.createElement("option");
		option.text = "Відвантаження з підготовчого відділення";
		option.value = 118;
		silageFrom.add(option);
		var option0 = document.createElement("option");
		option0.text = "Відвантаження з екстракційного цеха";
		option0.value = 121;
		silageFrom.add(option0);
		var option1 = document.createElement("option");
		option1.text = "Прихід при інвентарізації";
		option1.value = 117;
		silageFrom.add(option1);

		len2=silageTo.length;
		silageTo.innerHTML="";
	   
		for (var i in bunkersTo) {
			if ((bunkersTo[i].ParentId == productId 
				&& bunkersTo[i].ClassificationId == classificationToId
				||bunkersTo[i].ParentId ==0 )
				) 
			{
				var option = document.createElement("option");
				option.text = bunkersTo[i].Name;
				option.value = bunkersTo[i].Id;
				silageTo.add(option);
			} 
		}

		var option = document.createElement("option");
		option.text = "Списання при інвентаризації";
		option.value = 115;
		silageTo.add(option);

		//var option = document.createElement("option");
		//option.text = "Бункер на фасування бігбегів №1";
		//option.value = 119;
		//silageTo.add(option);

		//var option = document.createElement("option");
		//option.text = "Бункер на фасування бігбегів №2";
		//option.value = 120;
		//silageTo.add(option);

		classificationsFrom.innerHTML="";
		classificationsTo.innerHTML="";
		if(productId==3||productId==13||productId==31)
		{
			var option2 = document.createElement("option");
			option2.text = "Не гранульований";
			option2.value = 8;
			classificationsFrom.add(option2);
			classificationsTo.add(option2);
		}
		else
		{
			var option3 = document.createElement("option");
			option3.text = "Не гранульований";
			option3.value = 8;
			classificationsFrom.add(option3);
			classificationsTo.add(option3);

			var option4 = document.createElement("option");
			option4.text = "Гранульований";
			option4.value = 7;
			classificationsFrom.add(option4);
			classificationsTo.add(option4);
		}
	}

	
	function move()
	{
		var silageFromId = $("#SilageFromId").val();
		var silageToId = $("#SilageToId").val();
		var quantity = $("#Quantity").val();
		if (silageFromId!=0 ||silageToId!=0 || quantity!=0) 
		{
		    $("#uiMove").prop("disabled", true);
			var $preparingModalInform = $("#preparing-modal-inform");
			$preparingModalInform.dialog({ modal: true });
			$preparingModalInform.text("Зачекайте будь ласка. \n Виконується обробка данних.");
			$.ajax({
				async: false,
				type: "POST",
				data: {
					ProductFromId: $("#ProductFromId").val(),
					SilageFromId: silageFromId,
					SilageToId: silageToId,
					ClassificationFromId: $("#ClassificationFromId").val(),
					ClassificationToId: $("#ClassificationToId").val(),
					Quantity: quantity
				},
				cache: false,
				url: 'Moving',
				success: function (data) {
					alert("Переміщення продукту відбулось успішно.");
					$preparingModalInform.dialog('close');
					window.location.replace("index");
				},
				error: function (xhr, testStatus, error) {
					alert("error: " + xhr + " " + testStatus + " " + error);
					$preparingModalInform.dialog('close');
					window.location.replace("index");
				}
			});
			;
		}
		else
		{
			alert("Для переміщення потрібно заповнити всі необхідні поля.");
		}
	}
</script>
<div id="preparing-modal-inform" title="Виконується запит" style="display: none;">
</div>
<div class="technologMeal float-left">
	<div class="buttons">
		<div class="buttons butblock buttonsmall float-left">
            @WebHelper.GetHomeTechnologPreparatory()
			<div>
				@using (Html.BeginForm("Index", "TechnologMeal", FormMethod.Get))
				{
					<input type="submit" name="submitButton" value="Оновити" />
				}
			</div>
			<div>
				@using (Html.BeginForm("SwitchMealLine", "TechnologMeal", FormMethod.Get))
				{
					<input type="submit" name="submitButton" value="Переключення потоків" />
				}
			</div>
			<div style="width:260px;">
				@using (Html.BeginForm("ReportProductMovementForm", "TechnologMeal", FormMethod.Get))
                {
                    <input type="submit" name="submitButton" value="Звіт: ручні переміщення складу" />
                }
			</div>
			<div>
				@using (Html.BeginForm("Index", "TechnologElevator", FormMethod.Get))
				{
					<input type="submit" name="submitButton" value="Елеватор" />
				}
			</div>
			<div>
				@using (Html.BeginForm("ReportSilostore", "TechnologElevator"))
				{
					<input type="submit" name="submitButton" value="Звіти" />
				}
			</div>
		</div>
	</div>
	@* Ручне переміщення *@
	<div class="float-left" style="width: 100%;">
		<div class="clear-fix">
			<span style="text-align:center;"><h3>Ручне переміщення</h3></span>
		</div>
		<div>
			<table class="tableSimple">
				<thead>
					<tr>
						<td>
							Сировина
						</td>
						<td>
							Характеристика
						</td>
						<td>
							Звідки
						</td>
						<td>
							Кількість в тонах
						</td>
						<td>
							Характеристика
						</td>
						<td>
							Куди
						</td>
						<td>
							Дія
						</td>
					</tr>
				</thead>
				<tbody>
					<tr style="height: 50px; line-height: 50px;">

						<td>
							@Html.DropDownListFor(
										m => m.ProductFromId,
										new SelectList(Model.Products.OrderBy(p => p.Name),
													   "Id",
													   "Name"), new { style = "width:150px;", onchange = "productChanged()" })
						</td>
						<td>
							@Html.DropDownListFor(
										m => m.ClassificationFromId,
										new SelectList(Model.Classifications,
													   "Id",
													   "Name"), new { style = "width:150px;", onchange = "ClassificationFromChanged()" })
						</td>
						<td>
							<select style="width:150px;" id="SilageFromId" name="SilageFromId"></select>
						</td>

						<td>
							<input style="width:150px;" type="text" id="Quantity" name="Quantity" value='@Model.Quantity' />
						</td>
						<td>
							@Html.DropDownListFor(
										m => m.ClassificationToId,
										new SelectList(Model.Classifications,
													   "Id",
													   "Name"), new { style = "width:150px;", onchange = "ClassificationToChanged()" })
						</td>
						<td>
							<select style="width:150px;" id="SilageToId" name="SilageToId"></select>
						</td>
						<td>
							<div class="buttons">
								<input id="uiMove" style="margin: 0 auto;" type="submit" value="Виконати" onclick="move()" />
							</div>
						</td>
					</tr>
				</tbody>
			</table>
		</div>
	</div>

	@* Состояние бункеров *@
	<div class="float-left" style="width: 100%;">
		<div class="clear-fix">
			<span style="text-align:center;"><h3>Поточний стан бункерів складу силосного типу</h3></span>
		</div>

		<div class="tableSilos" style="margin:0 auto;">
			<div style="text-align:center; width: 100%;"><h3 style="padding-top:0px;">25 ряд</h3></div>
				<table>
					<tbody>
						<tr>
							@{var index = 0;
							for (int j = 0; j < 13; j++)
							{
								index = j + 65;
								<td>@Model.Bunkers[index].Name</td>
                                <td><div class="popup">@Model.Bunkers[index].ProductShortName<span>@Model.Bunkers[index].ProductName</span><div></td>
                            }
}
						</tr>
						<tr>
							@for (int j = 0; j < 13; j++)
							{
								index = j + 65;
								double weight;
								double.TryParse(@Model.Bunkers[@index].Weight, out weight);
								switch (bunkers[@index].Value)
								{

									case 0:
										if (weight < 0)
										{
											<td colspan="2" style="color:red;">@Model.Bunkers[@index].Weight</td>}
										else
										{
											<td colspan="2">@Model.Bunkers[@index].Weight</td>}
										break;
									case 1:
										if (weight < 0)
										{
											<td colspan="2" style="color:red; background-color:yellow;">@Model.Bunkers[@index].Weight</td>}
										else
										{
											<td colspan="2" style="background-color:yellow;">@Model.Bunkers[@index].Weight</td>}
										break;
									case 2:
										if (weight < 0)
										{
											<td colspan="2" style="color:red; background-color:orange;">@Model.Bunkers[@index].Weight</td>}
										else
										{
											<td colspan="2" style="background-color:orange;">@Model.Bunkers[@index].Weight</td>}
										break;
								}
							}
						</tr>
						<tr><td colspan="26"><br /></td></tr>
						<tr>
							@for (int j = 0; j < 13; j++)
							{
								index = j * 2 + 40;
								<td>@Model.Bunkers[index].Name</td>
                                    <td><div class="popup">@Model.Bunkers[index].ProductShortName<span>@Model.Bunkers[index].ProductName</span><div></td>
                            }
						</tr>
						<tr>
							@for (int j = 0; j < 13; j++)
							{
								index = j * 2 + 40;
								double weight;
								double.TryParse(@Model.Bunkers[@index].Weight, out weight);
								switch (bunkers[@index].Value)
								{

									case 0:
										if (weight < 0)
										{
											<td colspan="2" style="color:red;">@Model.Bunkers[@index].Weight</td>}
										else
										{
											<td colspan="2">@Model.Bunkers[@index].Weight</td>}
										break;
									case 1:
										if (weight < 0)
										{
											<td colspan="2" style="color:red; background-color:yellow;">@Model.Bunkers[@index].Weight</td>}
										else
										{
											<td colspan="2" style="background-color:yellow;">@Model.Bunkers[@index].Weight</td>}
										break;
									case 2:
										if (weight < 0)
										{
											<td colspan="2" style="color:red; background-color:orange;">@Model.Bunkers[@index].Weight</td>}
										else
										{
											<td colspan="2" style="background-color:orange;">@Model.Bunkers[@index].Weight</td>}
										break;
								}
							}
						</tr>
						<tr><td colspan="26"><br /></td></tr>
						<tr>
							@for (int j = 0; j < 13; j++)
							{
								index = j * 2 + 39;
								<td>@Model.Bunkers[index].Name</td>
                                <td><div class="popup">@Model.Bunkers[index].ProductShortName<span>@Model.Bunkers[index].ProductName</span><div></td>
                            }
						</tr>
						<tr>
							@for (int j = 0; j < 13; j++)
							{
								index = j * 2 + 39;
								double weight;
								double.TryParse(@Model.Bunkers[@index].Weight, out weight);
								switch (bunkers[@index].Value)
								{

									case 0:
										if (weight < 0)
										{
											<td colspan="2" style="color:red;">@Model.Bunkers[@index].Weight</td>}
										else
										{
											<td colspan="2">@Model.Bunkers[@index].Weight</td>}
										break;
									case 1:
										if (weight < 0)
										{
											<td colspan="2" style="color:red; background-color:yellow;">@Model.Bunkers[@index].Weight</td>}
										else
										{
											<td colspan="2" style="background-color:yellow;">@Model.Bunkers[@index].Weight</td>}
										break;
									case 2:
										if (weight < 0)
										{
											<td colspan="2" style="color:red; background-color:orange;">@Model.Bunkers[@index].Weight</td>}
										else
										{
											<td colspan="2" style="background-color:orange;">@Model.Bunkers[@index].Weight</td>}
										break;
								}
							}
						</tr>
						<tr><td colspan="26"><h3>9 ряд</h3></td></tr>
						<tr>
							 @for (int j = 0; j < 13; j++)
							 {
								 index = j * 2;
								<td>@Model.Bunkers[index].Name</td>
                                <td><div class="popup">@Model.Bunkers[index].ProductShortName<span>@Model.Bunkers[index].ProductName</span><div></td>
                             }
							
						</tr>
						<tr>
							@for (int j = 0; j < 13; j++)
							{
								index = j * 2;
								double weight;
								double.TryParse(@Model.Bunkers[@index].Weight, out weight);
								switch (bunkers[@index].Value)
								{

									case 0:
										if (weight < 0)
										{<td colspan="2" style="color:red;">@Model.Bunkers[@index].Weight</td>}
										else
										{<td colspan="2">@Model.Bunkers[@index].Weight</td>}
										break;
									case 1:
										if (weight < 0)
										{
										<td colspan="2" style="color:red; background-color:yellow;">@Model.Bunkers[@index].Weight</td>}
										else
										{
											<td colspan="2" style="background-color:yellow;">@Model.Bunkers[@index].Weight</td>}
										break;
									case 2:
										if (weight < 0)
										{
											<td colspan="2" style="color:red; background-color:orange;">@Model.Bunkers[@index].Weight</td>}
										else
										{
											<td colspan="2" style="background-color:orange;">@Model.Bunkers[@index].Weight</td>}
										break;
								}
							}
						</tr>
						<tr><td colspan="26"><br /></td></tr>
						<tr>
							@for (int j = 0; j < 13; j++)
							{
								index = j * 2 + 1;
								<td>@Model.Bunkers[index].Name</td>
                                <td><div class="popup">@Model.Bunkers[index].ProductShortName<span>@Model.Bunkers[index].ProductName</span><div></td>
                            }
						</tr>
						<tr>
							@for (int j = 0; j < 13; j++)
							{
								index = j * 2 + 1;
								double weight;
								double.TryParse(@Model.Bunkers[@index].Weight, out weight);
								switch (bunkers[@index].Value)
								{

									case 0:
										if (weight < 0)
										{
										<td colspan="2" style="color:red;">@Model.Bunkers[@index].Weight</td>}
										else
										{
										<td colspan="2">@Model.Bunkers[@index].Weight</td>}
										break;
									case 1:
										if (weight < 0)
										{
											<td colspan="2" style="color:red; background-color:yellow;">@Model.Bunkers[@index].Weight</td>}
										else
										{
											<td colspan="2" style="background-color:yellow;">@Model.Bunkers[@index].Weight</td>}
										break;
									case 2:
										if (weight < 0)
										{
											<td colspan="2" style="color:red; background-color:orange;">@Model.Bunkers[@index].Weight</td>}
										else
										{
											<td colspan="2" style="background-color:orange;">@Model.Bunkers[@index].Weight</td>}
										break;
								}
							}
						</tr>
						<tr><td colspan="26"><br /></td></tr>
						<tr>
							@for (int j = 0; j < 13; j++)
							{
								index = j + 26;
								<td>@Model.Bunkers[index].Name</td>
                                <td><div class="popup">@Model.Bunkers[index].ProductShortName<span>@Model.Bunkers[index].ProductName</span><div></td>
                            }
						</tr>
						<tr>
							@for (int j = 0; j < 13; j++)
							{
								index = j + 26;
								double weight;
								double.TryParse(@Model.Bunkers[@index].Weight, out weight);
								switch (bunkers[@index].Value)
								{

									case 0:
										if (weight < 0)
										{
										<td colspan="2" style="color:red;">@Model.Bunkers[@index].Weight</td>}
										else
										{
										<td colspan="2">@Model.Bunkers[@index].Weight</td>}
										break;
									case 1:
										if (weight < 0)
										{
											<td colspan="2" style="color:red; background-color:yellow;">@Model.Bunkers[@index].Weight</td>}
										else
										{
											<td colspan="2" style="background-color:yellow;">@Model.Bunkers[@index].Weight</td>}
										break;
									case 2:
										if (weight < 0)
										{
											<td colspan="2" style="color:red; background-color:orange;">@Model.Bunkers[@index].Weight</td>}
										else
										{
											<td colspan="2" style="background-color:orange;">@Model.Bunkers[@index].Weight</td>}
										break;
								}
							}
						</tr>
						

					</tbody>
				</table>
		</div>
		@* Легенда обозначения бункеров *@
        <div class="legend">
            <table border="1" style="border-collapse: collapse; border: 1px solid #AEAEAE;">
                <tr>
                    <td>ШСянГ</td>
                    <td>Шрот соєвий негранульований</td>
                    <td>ЛСянГ</td>
                    <td>Лушпиння сої негранульоване</td>
                    <td>ШСнГ</td>
                    <td>Шрот соняшниковий негранульований</td>
                    <td>МСя</td>
                    <td>Макуха соева</td>
                </tr>
                <tr>
                    <td>ШСяГ</td>
                    <td>Шрот соєвий гранульований</td>
                    <td>ЛСяГ</td>
                    <td>Лушпиння сої гранульоване</td>
                    <td>ШСкГ</td>
                    <td>Шрот соняшниковий гранульований</td>
                    <td>МС</td>
                    <td>Макуха соняшникова</td>
                </tr>
                <tr>
                    <td>ШРнГ</td>
                    <td>Шрот рiпаковий негранульований</td>
                    <td>ЛСнГ</td>
                    <td>Лушпиння соняшника негранульоване</td>
                    <td>ШСВнГ</td>
                    <td>Шрот соняшниковий високопротеїновий негранульований</td>
                    <td>МР</td>
                    <td>Макуха рiпакова</td>
                </tr>
                <tr>
                    <td>ШРГ</td>
                    <td>Шрот рiпаковий гранульований</td>
                    <td>ЛСГ</td>
                    <td>Лушпиння соняшника гранульоване</td>
                    <td>ШСВГ</td>
                    <td>Шрот соняшниковий високопротеїновий гранульований</td>
                    <td>МРГ</td>
                    <td>Макуха рiпакова гранульована</td>
                </tr>
            </table>
        </div>
	</div>

	<div class="leftcolumnTM float-left">

		@* Поточний стан складу силосного типу *@
		<div class="float-left stanSilosov">
			<div class="clear-fix">
				<span style="text-align:center;"><h3>Поточний стан складу силосного типу</h3></span>
			</div>
			<div class="float-left">
				<table class="tableSimple">
					<thead>
						<tr>
							<td colspan="2">
								Макуха
							</td>
						</tr>
						<tr>
							<td>
								Продукт
							</td>
							<td>
								Кількість, тн
							</td>
						</tr>
					</thead>
					<tbody>
						@foreach (var productWeight in Model.CurrentStorageState.OilCakesWeight)
						{
							<tr>
								<td>
									@productWeight.ProductName
								</td>
								<td>
									@string.Format("{0:0.000}", productWeight.Weight)
								</td>
							</tr>
						}
					</tbody>
				</table>
			</div>
			<div class="float-left">
				<table class="tableSimple">
					<thead>
						<tr>
							<td colspan="2">
								Шрот
							</td>
						</tr>
						<tr>
							<td>
								Продукт
							</td>
							<td>
								Кількість, тн
							</td>
						</tr>
					</thead>
					<tbody>
						@foreach (var productWeight in Model.CurrentStorageState.SchrothWeight)
						{
							<tr>
								<td>
									@productWeight.ProductName
								</td>
								<td>
									@string.Format("{0:0.000}", productWeight.Weight)
								</td>
							</tr>
						}
					</tbody>
				</table>
			</div>
			<div class="float-left">
				<table class="tableSimple">
					<thead>
						<tr>
							<td colspan="2">
								Гран. шрот
							</td>
						</tr>
						<tr>
							<td>
								Продукт
							</td>
							<td>
								Кількість, тн
							</td>
						</tr>
					</thead>
					<tbody>
						@foreach (var productWeight in Model.CurrentStorageState.SchrothGranWeight)
						{
							<tr>
								<td>
									@productWeight.ProductName
								</td>
								<td>
									@string.Format("{0:0.000}", productWeight.Weight)
								</td>
							</tr>
						}
					</tbody>
				</table>
			</div>
			<div class="float-left">
				<table class="tableSimple">
					<thead>
						<tr>
							<td colspan="2">
								Лушпиння
							</td>
						</tr>
						<tr>
							<td>
								Продукт
							</td>
							<td>
								Кількість, тн
							</td>
						</tr>
					</thead>
					<tbody>
						@foreach (var productWeight in Model.CurrentStorageState.HuskCharacteristicWeight)
						{
							<tr>
								<td>
									@productWeight.ProductName
								</td>
								<td>
									@string.Format("{0:0.000}", productWeight.Weight)
								</td>
							</tr>
						}
					</tbody>
				</table>
			</div>
			<div class="float-left">
				<table class="tableSimple">
					<thead>
						<tr>
							<td colspan="2">
								Гран.
								лушпиння
							</td>
						</tr>
						<tr>
							<td>
								Продукт
							</td>
							<td>
								Кількість, тн
							</td>
						</tr>
					</thead>
					<tbody>
						@foreach (var productWeight in Model.CurrentStorageState.HuskCharacteristicGranWeight)
						{
							<tr>
								<td>
									@productWeight.ProductName
								</td>
								<td>
									@string.Format("{0:0.000}", productWeight.Weight)
								</td>
							</tr>
						}
					</tbody>
				</table>
			</div>
		</div>

		@* Поточний стан відділення фасування *@
		<div class="float-left stanBigbeg">
			<div class="clear-fix">
				<span style="text-align:center;"><h3>Поточний стан відділення фасування</h3></span>
			</div>
			<div class="float-left">
				<table class="tableSimple">
					<thead>
						<tr>
							<td colspan="5">
								Відділення фасування (Бункер №1)
							</td>
						</tr>
						<tr>
							<td>
								Продукт
							</td>
							<td>
								Характеристика
							</td>
							<td>
								Прихід
							</td>
							<td>
								Витрата
							</td>
							<td>
								Стан
							</td>
						</tr>
					</thead>
					<tbody>
						@{var bunker1 = Model.CurrentStorageState.BigbagBunker1;
						<tr>
							<td>
								@bunker1.ProductName
							</td>
							<td>
								@bunker1.ClassificationName
							</td>
							<td>
								@string.Format("{0:0.000}", bunker1.IncomeWeight)
							</td>
							<td>
								@string.Format("{0:0.000}", bunker1.OutcomeWeight/1000)
							</td>
							<td>
								@string.Format("{0:0.000}", bunker1.Weight)
							</td>
						</tr>
						}
					</tbody>
				</table>
			</div>
			<div class="float-left">
				<table class="tableSimple">
					<thead>
						<tr>
							<td colspan="5">
								Відділення фасування (Бункер №2)
							</td>
						</tr>
						<tr>
							<td>
								Продукт
							</td>
							<td>
								Характеристика
							</td>
							<td>
								Прихід
							</td>
							<td>
								Витрата
							</td>
							<td>
								Стан
							</td>
						</tr>
					</thead>
					<tbody>
						@{var bunker2 = Model.CurrentStorageState.BigbagBunker2;
						<tr>
							<td>
								@bunker2.ProductName
							</td>
							<td>
								@bunker2.ClassificationName
							</td>
							<td>
								@string.Format("{0:0.000}", bunker2.IncomeWeight)
							</td>
							<td>
								@string.Format("{0:0.000}", bunker2.OutcomeWeight/1000)
							</td>
							<td>
								@string.Format("{0:0.000}", bunker2.Weight)
							</td>
						</tr>
						}
					</tbody>
				</table>
			</div>
			<div style="width: 100%;">
				<table class="tableSimple">
					<thead>
						<tr>
							<td colspan="3">
								Склад біг-бегів
							</td>
						</tr>
						<tr>
							<td>
								Продукт
							</td>
							<td>
								Характеристика
							</td>
							<td>
								Стан, шт.
							</td>
						</tr>
					</thead>
					<tbody>
						@foreach (var item in Model.CurrentStorageState.BigBagStorage)
						{
							<tr>
								<td>
									@item.ProductName
								</td>
								<td>
									@item.ClassificationName
								</td>
								<td>
									@string.Format("{0:0.000}", item.Weight)
								</td>
							</tr>
						}
					</tbody>
				</table>
			</div>
		</div>

		@* Показники за зміну: *@
		<div class="float-left shiftReport">
			<div class="clear-fix">
				<span style="text-align:center;"><h3>Показники за зміну</h3></span>
			</div>
			@* Селектор отчета *@
			<div class="selector">
				@using (Html.BeginForm("Index", "TechnologMeal", FormMethod.Post))
				{
					<table class="tableSimple selector">
						<thead>
							<tr style="height: 25px; line-height: 25px;">
								<td>
									<span style="font-size:small;">@Html.Label("Дата та номер зміни:")</span>
								</td>
								<td>
									<div style="text-align:center;">
										@Html.DropDownListFor(m => m.ShiftId, new SelectList(Model.Shifts, "Id", "Name", Model.ShiftId))
									</div>
								</td>
								<td>
									<div class="buttons">
										<input style="margin: 0 auto;" type="submit" value="Показати" id="show" />
									</div>
								</td>
							</tr>
						</thead>
					</table>
				}
			</div>
			<div class="shift">
				<table class="tableSimple">
					<thead>
						<tr>
							<td rowspan="2">
								Кількість авто до відвантаження, шт
							</td>
							<td rowspan="2">
								Необхідна вага по ТТН, тн
							</td>
							<td rowspan="2">
								Подане на підготовче відділення, тн
							</td>
							<td colspan="4">
								Подане на відділення фасування
							</td>
							<td colspan="5">
								Прийнято на зберігання (на склад)
							</td>
						</tr>
						<tr>
							<td>
								шрот, тн
							</td>
							<td>
								лушпиння, тн
							</td>
							<td>
								гран. шрот, тн
							</td>
							<td>
								гран. лушпиння, тн
							</td>
							<td>
								макуха, тн
							</td>
							<td>
								шрот, тн
							</td>
							<td>
								лушпиння, тн
							</td>
							<td>
								гран. шрот, тн
							</td>
							<td>
								гран. лушпиння, тн
							</td>
						</tr>
					</thead>

					@{
						var currentShift = Model.TechnologMealCurrentShift;

						<tr>
							<td>
								@currentShift.AmountCarsBeforeTruck
							</td>
							<td>
								@string.Format("{0:0.000}", currentShift.AmountExpectedRevenuesByTTN)
							</td>
							<td>
								@string.Format("{0:0.000}", currentShift.AmountGoOnProduction)
							</td>
							<td>
								@string.Format("{0:0.000}", currentShift.PackedSchrotte)
							</td>
							<td>
								@string.Format("{0:0.000}", currentShift.PackedHusk)
							</td>
							<td>
								@string.Format("{0:0.000}", currentShift.PackedSchrotteGran)
							</td>
							<td>
								@string.Format("{0:0.000}", currentShift.PackedHuskGran)
							</td>
							<td>
								@string.Format("{0:0.000}", currentShift.StoragedCake)
							</td>
							<td>
								@string.Format("{0:0.000}", currentShift.StoragedSchrotte)
							</td>
							<td>
								@string.Format("{0:0.000}", currentShift.StoragedHusk)
							</td>
							<td>
								@string.Format("{0:0.000}", currentShift.StoragedSchrotteGran)
							</td>
							<td>
								@string.Format("{0:0.000}", currentShift.StoragedHuskGran)
							</td>
						</tr>
					}
				</table>
			</div>
		</div>


		@* Показники за період *@
		<div class="float-left periodReport">
			<div class="clear-fix">
				<span style="text-align:center;"><h3>Показники за період</h3></span>
			</div>
			<div class="clear-fix">
				@using (Ajax.BeginForm("Index", new AjaxOptions
	{
		InsertionMode = InsertionMode.Replace,
		// UpdateTargetId = "preparationShiftView",
		HttpMethod = "get"
	}
	))
				{
					<div class="selector">
						<table class="tableSimple selector">
							<thead>
								<tr style="height: 25px; line-height: 25px;">
									<td>
										<span style="font-size:small;">@Html.LabelFor(model => model.DateBegin)</span>
									</td>
									<td>
										<div style="text-align:center;">
											<input id="DateBegin" name="DateBegin" style="width:70px;" value='@string.Format("{0:dd.MM.yyyy}", Model.DateBegin)' />
										</div>
									</td>

									<td>
										<span style="font-size:small;">@Html.LabelFor(model => model.TimeBegin)</span>
									</td>
									<td>
										<div style="text-align:center;">
											<input name="TimeBegin" style="width:60px;" value='@string.Format("{0:HH:mm:ss}", Model.TimeBegin)' />
										</div>
									</td>


									<td>
										<span style="font-size:small;">@Html.LabelFor(model => model.DateFinish)</span>
									</td>
									<td>
										<div style="text-align:center;">
											<input id="DateFinish" name="DateFinish" style="width:70px;" value='@string.Format("{0:dd.MM.yyyy}", Model.DateFinish)' />
										</div>
									</td>
									<td>
										<span style="font-size:small;">@Html.LabelFor(model => model.TimeFinish)</span>
									</td>
									<td>
										<div style="text-align:center;">
											<input name="TimeFinish" style="width:60px;" value='@string.Format("{0:HH:mm:ss}", Model.TimeFinish)' />
										</div>
									</td>

									<td>
										<div class="buttons">
											<input type="submit" value="Відобразити" />
										</div>
									</td>
								</tr>
							</thead>
						</table>
					</div>
				}
				@* Таблица  Показники за період *@
				<div class="period">
					<table class="tableSimple">
						<thead>
							<tr>
								<td rowspan="2">
									Дата
								</td>
								<td rowspan="2">
									Подане на виробництво (зміна)
								</td>
								<td colspan="2">
									Подане на фасування, тн
								</td>
								<td colspan="4">
									Подане на зберігання, тн
								</td>
							</tr>
							<tr>
								<td>
									гран. шрот
								</td>
								<td>
									гран. лушпиння
								</td>
								<td>
									шрот
								</td>
								<td>
									лушпиння
								</td>
								<td>
									гран. шрот
								</td>
								<td>
									гран. лушпиння
								</td>
							</tr>
						</thead>
						<tbody>
							@foreach (var item in Model.MealShifts)
							{
								<tr>
									<td>@item.ShiftDate</td>
									<td>@item.ShiftName</td>
									<td>@string.Format("{0:0.000}", item.PackedSchrotte)</td>
									<td>@string.Format("{0:0.000}", item.PackedHusk)</td>
									<td>@string.Format("{0:0.000}", item.StoragedSchrotte)</td>
									<td>@string.Format("{0:0.000}", item.StoragedHusk)</td>
									<td>@string.Format("{0:0.000}", item.StoragedSchrotteGran)</td>
									<td>@string.Format("{0:0.000}", item.StoragedHuskGran)</td>
								</tr>
							}
						</tbody>
						<tfoot>
							<tr>
								<td colspan="2">Усьго</td>
								<td>@string.Format("{0:0.000}", Model.MealShifts.Sum(s => s.PackedSchrotte))</td>
								<td>@string.Format("{0:0.000}", Model.MealShifts.Sum(s => s.PackedHusk))</td>
								<td>@string.Format("{0:0.000}", Model.MealShifts.Sum(s => s.StoragedSchrotte))</td>
								<td>@string.Format("{0:0.000}", Model.MealShifts.Sum(s => s.StoragedHusk))</td>
								<td>@string.Format("{0:0.000}", Model.MealShifts.Sum(s => s.StoragedSchrotteGran))</td>
								<td>@string.Format("{0:0.000}", Model.MealShifts.Sum(s => s.StoragedHuskGran))</td>
							</tr>
						</tfoot>
					</table>
				</div>
			</div>
		</div>
	 </div>

	<div class="rightcolumnTM float-left">
		<div class="clear-fix">
			<span style="text-align:center;"><h3>Авто на території</h3></span>
		</div>
		<div class="float-left">
			@* Partrial view *@
			<div>
				@{
					Html.RenderPartial("_techologMeal");
				}
			</div>
			<br />
			<div>
				@{
					Html.RenderPartial("_technologMealShipment");
				}
			</div>
		</div>
	</div>
</div>