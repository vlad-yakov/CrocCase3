<template>
	<div class="search">
		<template>
			<v-btn class="mrg" color="#00A460" dark @click.stop="search = !search">
				<v-icon>mdi-magnify</v-icon>
			</v-btn>
		</template>
		
		<v-navigation-drawer
			app
			fixed
			floating
			v-model="search"
			absolute
			temporary
			right="true"
			width="440px"
			overlay-opacity="0"
		>
			<v-sheet>
				<v-row>
					<v-col cols="11"></v-col>
					<v-col cols="12" sm="9" offset="0px">
						<v-text-field
							v-model="value"
							dense
							type="text"
							clearable
							label="Найти проект"
							color="#00A460"
							id="poisk">
						</v-text-field>
					</v-col>
					
					<v-btn dark color="#00A460" @click=giveProjPartName()> Найти</v-btn>
				</v-row>
			</v-sheet>
			<h3>Мои проекты:</h3>
			<div class="myProjects">
				<v-list-item>
					<v-list-item-content>
						<v-list-item-title >Создание базы данных</v-list-item-title>
					</v-list-item-content>
				</v-list-item>
			</div>
			<hr color="#00A460"/>
			<div class="myProjects">
				<v-list-item>
					<v-list-item-content >
						<v-list-item-title >Перезапись презентации</v-list-item-title>
					</v-list-item-content>
				</v-list-item>
			</div>
		</v-navigation-drawer>
	</div>
</template>

<script>
import Vue from "vue";

export default Vue.component("search", {
	props: {
	},
	data() {
		return {
			search: false,
			proj: '',
			usproj: '',
			value: '',
			enterName: '',
		};
	},
	
	methods: {
		/*
	async giveProjPartName() {
		try {		
			let enterName = encodeURIComponent((document.getElementById('poisk').value));
			let response =  fetch(`https://localhost:5001/GetAllProjectsByPartName?partName=${enterName}`, {
				mode: "cors",
			});
			if (response.ok) {
				let json = await response.json();
				return (json)
			}
		} catch(response) {
			console.log( "Ошибка вывода проектов по введённой строке: "+ response.status)
		}
	},
		*/
		async giveProjPartName() {
			let enterName = encodeURIComponent((document.getElementById('poisk').value));
			fetch(`https://localhost:5001/GetAllProjectsByPartName?partName=${enterName}`, {
				mode: "cors",
			}).then(response => response.json())
				.catch(err => alert(err))
		},
		
		giveProjByUserId: async function() {
			//let UserId = 6;
			let response = await fetch("https://localhost:5001/GetAllProjectsByUserId?userId=8", {
				mode: "cors",
			})
			if(response.ok) {
				let json = await response.json();
				return json;
			}
			else {
				console.log("Oшибкa вывода проектов в которых участвует сотрудник: "  + response.status)
			}
		}
	},
	
});
</script>

<style lang="scss" scoped>
.mrg {
	margin: 5px;
}

.v-navigation-drawer {
	padding: 10px;
}

.v-text-field {
	margin: 15px;
}

.myProjects {
	margin: 5px 0px 5px 30px;
}

hr {
	margin: 15px;
}

h3 {
	padding: 7px 15px;
}
</style>
