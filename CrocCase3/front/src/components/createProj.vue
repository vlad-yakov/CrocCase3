<template>
	<!--Окно создания/редактирования проекта,
			Кнопка только у администраторов-->
	<div class="proj">
		<v-dialog v-model="addProj" max-width="500" max-height="800px">
			<template v-slot:activator="{ on, attrs }">
				<v-btn
					class="mrg"
					v-bind="attrs"
					v-on="on"
					color="#00A460"
					@click="editProj = true"
				>
					<v-icon color="white"> mdi-file-plus-outline </v-icon>
				</v-btn>
			</template>
			
			<v-card>
				<v-container>
					<h3>Проект</h3>
					<v-form @submit.prevent="addEvent">
						<v-sheet>
							<h4>Название проекта</h4>
							<v-row>
								<v-text-field
									v-model="nameProj"
									outlined
									dense
									color="#00A460"
									id="poisk"
									class="pa-2">
								
								</v-text-field>
							</v-row>
							
							<h4>Рабочее время</h4>
							
							<v-row>
								<v-col>
									<v-text-field
										dense
										type="time"
										v-model="beginTime"
										clearable
										color="#00A460">
									</v-text-field>
								</v-col>
								
								<v-col>
									<v-text-field
										dense
										type="time"
										v-model="endTime"
										clearable
										color="#00A460">
									</v-text-field></v-col>
							</v-row>
							
							<h4>Дни недели</h4>
							
							<v-row dense>
								
								<v-col>
									<v-checkbox
										v-model="checkbox"
										color="#00A460"
										label="Пн">
									</v-checkbox>
								</v-col>
								
								<v-col>
									<v-checkbox
										class="px-2"
										v-model="checkbox"
										color="#00A460"
										label="Вт">
									</v-checkbox>
								</v-col>
								
								<v-col>
									<v-checkbox
										class="px-2"
										v-model="checkbox"
										color="#00A460"
										label="Ср">
									</v-checkbox>
								</v-col>
								
								<v-col>
									<v-checkbox
										outlined
										v-model="checkbox"
										color="#00A460"
										label="Чт">
									</v-checkbox>
								</v-col>
								
								<v-col>
									<v-checkbox
										v-model="checkbox"
										color="#00A460"
										label="Пт">
									</v-checkbox>
								</v-col>
								
								<v-col>
									<v-checkbox
										v-model="checkbox"
										color="#00A460"
										label="Сб"
									></v-checkbox>
								</v-col>
								
								<v-col>
									<v-checkbox
										v-model="checkbox" color="#00A460"
										label="Вс"
									></v-checkbox>
								</v-col>
							</v-row>
							
							<h4>Состав команды</h4>
							<v-row dense>
								<v-select
									v-model="select" :names="names" name-text="name" label="ФИО" return-object single-line>
								</v-select>
								
								<v-btn dense color="#00A460" small class="ma-2">
									<v-icon color="white">
										mdi-account-plus
									</v-icon>
								</v-btn>
							</v-row>
							<v-list-item class="px-1" >
								<v-list-item-content>
									<v-list-item-title v-for="userPr of usersPr" :key="userPr.id">{{userPr.name}}</v-list-item-title>
								</v-list-item-content>
							</v-list-item>
							
							<v-row dense>
								
								<v-col>
									<v-btn
										dark
										height="32px"
										small
										color="#FF0000"
										class="ma-1"
										@click.stop="delOnce = false">
										Удалить
									</v-btn>
								</v-col>
								
								<v-spacer></v-spacer>
								<v-spacer></v-spacer>
								
								<v-col>
									<v-btn
										height="32px"
										small
										dark
										color="#00A460"
										class="ma-1"
										@click.stop="keepProj = false">
										Сохранить
									</v-btn>
								</v-col>
								
								<v-col>
									<v-btn
										@click="addProj = !addProj"
										dark
										height="32px"
										small
										color="#666666"
										class="ma-1">
										Отмена
									</v-btn>
								</v-col>
							
							</v-row>
						</v-sheet>
					</v-form>
				</v-container>
			</v-card>
		</v-dialog>
	</div>
</template>

<script>
import Vue from "vue";

export default Vue.component("newproject", {
	data() {
		return {
			addProj: false,
			
		};
		
	},
	methods: {
		async giveAllUsersByProjectId() {
		},
	},
});
</script>

<style lang="scss" scoped>

@font-face {
	font-family: "CrocRegular";
	src: url("../fonts/CrocRegular.eot");
	src: url("../fonts/CrocRegular.eot") format("embedded-opentype"),
	url("../fonts/CrocRegular.svg#CrocRegular") format("svg"),
	url("../fonts/CrocRegular.ttf") format("truetype");
}

.v-container {
	font-family: "CrocRegular";
}

.v-text-field {
	padding: 0px;
	margin: 7px 10px 2px 10px;
	
	&.date-picker-input {
		color:#00A460;
	}
	
}

h4 {
	padding: 3px;
}

h3 {
	text-align: center;
	color: #00A460;
	font-size: 21px
}

.mrg {
	margin: 5px;
}

.v-list-item {
	overflow: auto;
}

</style>