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
							dense
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
						<v-list-item-title v-for="usproj in giveProjByUserId()" :key="usproj.id">{{usproj.name}}</v-list-item-title>
					</v-list-item-content>
				</v-list-item>
			</div>
			<hr color="#00A460"/>
			<div class="myProjects">
				<v-list-item>
					<v-list-item-content >
						<v-list-item-title v-for="proj in giveProjPartName()" :key="proj.id">{{proj.name}}</v-list-item-title>
					</v-list-item-content>
				</v-list-item>
			</div>
		</v-navigation-drawer>
	</div>
</template>

<script>
import Vue from "vue";

export default Vue.component("search", {
	props: [],
	data() {
		return {
			search: false,
		};
	},
	
	methods: {
	async giveProjPartName() {
			let enterName = encodeURIComponent(document.getElementById('poisk').innerHTML); 
				let response = await fetch(``, {
					mode: "cors",
				});
			if(response.ok) {
				let json = JSON.parse(await response.json());
				alert(json)
				return (json.result);
			}
			
			else {
				alert( "Статус ошибки: "+response.status)
			}
		},
		
		giveProjByUserId: async function() {
			//let UserId = 6;
			let response = await fetch("https://localhost:5001/GetAllProjectsByUserId?userId=8", {
				mode: "cors",
			})
			if(response.ok) {
				let reply = JSON.parse(await response.json());
				alert(reply)
				return reply.result;
			}
			else {
				alert(" Oшибкa: "  + response.status)
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
