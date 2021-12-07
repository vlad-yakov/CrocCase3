<template>
	<div id="graph">
		<hr class="stroke" >
		<v-sheet app height="54" color="#F5F5F5" class="d-flex">
			<v-btn icon class="ma-2" @click="$refs.calendar.prev()">
				<v-icon>mdi-chevron-left</v-icon>
			</v-btn>
			<v-toolbar-title class="ma-3" v-if="$refs.calendar">
				{{ $refs.calendar.title }}
			</v-toolbar-title>
			
			<v-btn class="ma-2" color="#00A460" dark @click="setToday">
				Сегодня
			</v-btn>
			<v-row>
				<v-col sm="4">
					<v-select
						v-model="type"
						:items="types"
						dense
						outlined
						color="#00A460"
						item-color="green accent-4"
						class="ma-2"
						label="день/неделя">
					</v-select>
				</v-col>
			</v-row>
			<v-spacer></v-spacer>
			<v-btn icon class="ma-2" @click="$refs.calendar.next()">
				<v-icon>mdi-chevron-right</v-icon>
			</v-btn>
		</v-sheet>
		
		<v-sheet height="84vh">
			<v-calendar
				app
				locale="ru"
				ref="calendar"
				v-model="focus"
				:weekdays="weekday"
				:type="type"
				:events="events"
				:event-overlap-mode="mode"
				:event-overlap-threshold="60"
				:event-color="getEventColor"
				:event-ripple="false"
				@change="getEvents"
				@click:event="showEvent"
				@mousedown:event="startDrag"
				@mousedown:time="startTime"
				@mousemove:time="mouseMove"
				@mouseup:time="endDrag"
				@mouseleave.native="cancelDrag"
				
			><!--по клику на сетке графика появляется график создания проекта-->
				<template #event="{ event, timed }">
					<div class="pl-1" v-html="getEventHTML(event, timed)" @onckick="!duty"></div>
					<div
						v-if="timed"
						class="v-event-drag-bottom"
						@mousedown.stop="extendBottom(event)"
					></div>
				</template>
				<template #day-body="{ date, week }">
					<div
						class="v-current-time"
						:class="{ first: date === week[0].date }"
						:style="{ top: nowY }"
					>
						<div class="v-current-time-time">
							{{ nowTime }}
						</div>
					</div>
				</template>
				&nbsp;
			</v-calendar>
			<duty></duty>
			
			<v-dialog
				max-width="500"
				v-model="selectedOpen"
				:close-on-content-click="false"
				:activator="selectedElement">
				<v-card>
					<v-container>
						<h3>Дежурство</h3>
						<v-form @submit.prevent="addEvent">
							<v-sheet>
								<v-row dense>
									<v-col
										class="pa-3"
										cols="3">
										<h4>Сотрудник</h4>
									</v-col>
									
									<v-col cols="9">
										<v-select
											dense
											outlined
											color="#00A460"
											v-model="select"
											:names="names"
											name-text="name"
											label="ФИО"
											return-object>
										</v-select>
									</v-col>
								</v-row>
								
								<v-row dense>
									<v-col
										class="pa-3"
										cols="3">
										<h4>Начало</h4>
									</v-col>
									
									<v-col cols="9">
										<v-text-field
											dense
											color="#00A460"
											v-model="start"
											type="datetime-local"
										>
										</v-text-field>
									</v-col>
								</v-row>
								
								<v-row dense>
									<v-col
										class="pa-3"
										cols="3">
										<h4>Окончание</h4>
									</v-col>
									
									<v-col cols="9">
										<v-text-field
											dense
											color="#00A460"
											v-model="end"
											type="datetime-local"
										></v-text-field>
									</v-col>
								</v-row>
								
								<v-row dense>
									<v-col
										class="pa-3">
										<h4>Повторять</h4>
									</v-col>
								
									
									
										<v-btn-toggle
											borderless
											dense 
											v-model="btnRatio"
											class="mx-4"
										>
											<v-btn
												borderless
												class="marg"
												small
												outlined>
												Никогда
											</v-btn>
											<v-btn
												borderless
												class="marg"
												small
												outlined>
												Каждый день
											</v-btn>
											<v-btn
												borderless
												class="marg"
												small
												outlined>
												Раз в неделю
											</v-btn>
											<v-btn
												borderless
												class="marg"
												small
												outlined>
												Раз в месяц
											</v-btn>
										</v-btn-toggle>
								</v-row>
								
								
								<v-row dense>
									<v-col
										class="pa-3"
										cols="3">
										<h4>Закончить</h4>
									</v-col>
									
									
									<v-col dense cols="10">
										<v-radio-group dense v-model="radioGroup">
											
											<v-radio style="align:center"
												color="#00A460"
												value
											><template v-slot:label>
												<span style="padding-left: 10px"><v-row align="baseline">После <v-text-field style="max-width: 100px; margin:5px" color="#00A460" dense outlined  v-model="recDuty" type="number"></v-text-field> дежурств</v-row></span>
											</template>
											</v-radio>
								
												<v-radio
													color="#00A460"
													value
												><template v-slot:label>
													<div style="padding-left: 10px"><v-row align="baseline">После <v-text-field color="#00A460" style="margin:5px" dense outlined width="10px" v-model="recCal" type="date"></v-text-field></v-row></div>
												</template>
												</v-radio>
											
										</v-radio-group>
									</v-col>
									
								
								</v-row>
								
								<v-row dense>
									<v-col>
										<v-btn
											height="32px"
											small
											dark
											color="#FF0000"
											class="ma-1"
											@click.stop="delAll = false">
											Удалить всё
										</v-btn>
									</v-col>
									
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
											@click="editProj = !editProj"
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
		
		<!--         {{ lastEvent }} -->
		</v-sheet>
	</div>
</template>

<script>
import Vuetify from "../plugins/vuetify";
import Vue from "vue";
import duty from "./duty";

export default Vue.component("graph", {
	// данные должны быть связаны с проектом
	components: {
		duty
	},
	data: () => ({
		type: "week",
		types: ["week", "day"],
		
		mode: "column",
		weekday: [1, 2, 3, 4, 5, 6, 0],
		
		selectedEvent: {},
		selectedElement: null,
		selectedOpen: false,
		
		focus: "",
		events: [], //метод для получения их с бд
		colors: ["blue","orange"], //метод для получения их с бд
		names: ["Сергеев Дмитрий","Авдеев Андрей"], //метод для получения их с бд
		
		dragEvent: null,
		dragStart: null,
		lastEvent: "",
		createEvent: null,
		createStart: null,
		extendOriginal: null,
		
		isMounted: false,
	}),
	computed: {
		nowY() {
			//текущий год
			const cal = this.$refs.calendar;
			if (!cal && !this.isMounted) {
				return -1;
			}
			
			return cal.timeToY(cal.times.now) + "px";
		},
		nowTime() {
			//текущее время для красной полоски
			const cal = this.$refs.calendar;
			if (!cal && !this.isMounted) {
				return -1;
			}
			
			return cal.formatTime(cal.times.now);
		},
	},
	mounted() {
		const cal = this.$refs.calendar;
		this.$refs.calendar.checkChange();
		
		window.Vuetify = Vuetify;
		window.app = this;
		window.cal = cal;
		
		this.isMounted = true;
		
		// scroll to the current time
		const minutes = cal.times.now.hour * 60 + cal.times.now.minute;
		const firstTime = Math.max(0, minutes - (minutes % 30) - 30);
		cal.scrollToTime(firstTime);
		
		// every minute update the current time bar
		setInterval(() => cal.updateTimes(), 60 * 1000);
	},
	methods: {
		
		getEvents({start, end}) {
			const events = [];
			
			const min = new Date(`${start.date}T00:00:00`);
			const max = new Date(`${end.date}T23:59:59`);
			const days = (max.getTime() - min.getTime()) / 86400000;
			const eventCount = this.rnd(days, days + 20);
			
			for (let i = 0; i < eventCount; i++) {
				const allDay = this.rnd(0, 3) === 0;
				const firstTimestamp = this.rnd(min.getTime(), max.getTime());
				const first = new Date(firstTimestamp - (firstTimestamp % 900000));
				const secondTimestamp = this.rnd(2, allDay ? 288 : 8) * 900000;
				const second = new Date(first.getTime() + secondTimestamp);
				
				events.push({
					name: this.names[this.rnd(0, this.names.length - 1)],
					start: this.formatDate(first, !allDay),
					end: this.formatDate(second, !allDay),
					color: this.colors[this.rnd(0, this.colors.length - 1)],
				});
			}
			
			this.events = events;
		},
		getEventColor(event) {
			const rgb = parseInt(event.color.substring(1), 16);
			const r = (rgb >> 16) & 0xff;
			const g = (rgb >> 8) & 0xff;
			const b = (rgb >> 0) & 0xff;
			
			return event === this.dragEvent
				? `rgba(${r}, ${g}, ${b}, 0.5)`
				: event === this.createEvent
					? `rgba(${r}, ${g}, ${b}, 0.5)`
					: event.color;
		},
		getEventHTML(event, timed) {
			const cal = this.$refs.calendar;
			let name = event.name;
			if (event.start.hasTime) {
				if (timed) {
					const showStart = event.start.hour < 12 && event.end.hour >= 12;
					const start = cal.formatTime(event.start, showStart);
					const end = cal.formatTime(event.end, true);
					const singline =
						(event.start, event.end) <= this.parsedEventOverlapThreshold;
					const separator = singline ? ", " : "<br>";
					return `<strong>${name}</strong>${separator}${start} - ${end}`;
				} else {
					const time = this.formatTime(event.start, true);
					return `<strong>${time}</strong> ${name}`;
				}
			}
			return name;
		},
		rnd(a, b) {
			return Math.floor((b - a + 1) * Math.random()) + a;
		},
		formatDate(a, withTime) {
			return withTime
				? `${a.getFullYear()}-${
					a.getMonth() + 1
				}-${a.getDate()} ${a.getHours()}:${a.getMinutes()}`
				: `${a.getFullYear()}-${a.getMonth() + 1}-${a.getDate()}`;
		},
		eventMove(e) {
			console.log("eventMove", e);
		},
		startDrag(e) {
			if (e.event && e.timed) {
				this.dragEvent = e.event;
				this.dragTime = null;
				this.extendOriginal = null;
			}
			
			this.lastEvent = "startDrag";
		},
		startTime(e) {
			const mouse = this.toDate(e);
			
			if (this.dragEvent && this.dragTime === null) {
				const start = this.toDate(this.dragEvent.start);
				
				this.dragTime = mouse.getTime() - start.getTime();
			} else {
				this.createStart = this.roundTime(mouse.getTime());
				this.createEvent = {
					name: "(no title)",
					start: this.toTimestamp(new Date(this.createStart)),
					end: this.toTimestamp(new Date(this.createStart)),
					color: this.colors[this.rnd(0, this.colors.length - 1)],
				};
				this.events.push(this.createEvent);
			}
			this.lastEvent = "startTime";
		},
		extendBottom(event) {
			this.createEvent = event;
			this.createStart = this.toDate(event.start).getTime();
			this.extendOriginal = event.end;
		},
		mouseMoveEvent(e) {
			console.log("mouseMoveEvent", e);
		},
		mouseMove(e) {
			if (this.dragEvent && this.dragTime !== null) {
				const start = this.toDate(this.dragEvent.start);
				const end = this.toDate(this.dragEvent.end);
				const duration = end.getTime() - start.getTime();
				const mouse = this.toDate(e);
				
				const newStartTime = mouse.getTime() - this.dragTime;
				const newStart = new Date(this.roundTime(newStartTime));
				const newEnd = new Date(newStart.getTime() + duration);
				
				this.dragEvent.start = this.toTimestamp(newStart);
				this.dragEvent.end = this.toTimestamp(newEnd);
			} else if (this.createEvent && this.createStart !== null) {
				const mouse = this.toDate(e).getTime();
				const mouseRounded = this.roundTime(mouse, false);
				const min = Math.min(mouseRounded, this.createStart);
				const max = Math.max(mouseRounded, this.createStart);
				
				this.createEvent.start = this.toTimestamp(new Date(min));
				this.createEvent.end = this.toTimestamp(new Date(max));
			}
		},
		endDrag() {
			this.dragTime = null;
			this.dragEvent = null;
			this.createEvent = null;
			this.createStart = null;
			this.extendOriginal = null;
			
			this.lastEvent = "endDrag";
		},
		cancelDrag() {
			if (this.createEvent) {
				if (this.extendOriginal) {
					this.createEvent.end = this.extendOriginal;
				} else {
					const i = this.events.indexOf(this.createEvent);
					if (i !== -1) {
						this.events.splice(i, 1);
					}
				}
			}
			
			this.createEvent = null;
			this.createStart = null;
			this.dragTime = null;
			this.dragEvent = null;
			
			this.lastEvent = "cancelDrag";
		},
		
		showEvent({nativeEvent, event}) {
			const open = () => {
				this.selectedEvent = event;
				this.selectedElement = nativeEvent.target;
				requestAnimationFrame(() =>
					requestAnimationFrame(() => (this.selectedOpen = true))
				);
			};
			
			if (this.selectedOpen) {
				this.selectedOpen = false;
				requestAnimationFrame(() => requestAnimationFrame(() => open()));
			} else {
				open();
			}
			
			nativeEvent.stopPropagation();
		},
		
		roundTime(time, down = true) {
			const roundDownTime = 15 * 60 * 1000; // 15 minutes
			
			return down
				? time - (time % roundDownTime)
				: time + (roundDownTime - (time % roundDownTime));
		},
		toDate(tms) {
			return typeof tms === "string"
				? new Date(tms)
				: new Date(tms.year, tms.month - 1, tms.day, tms.hour, tms.minute);
		},
		toTimestamp(date) {
			return `${date.getFullYear()}-${
				date.getMonth() + 1
			}-${date.getDate()} ${date.getHours()}:${date.getMinutes()}`;
		},
		
		viewDay({date}) {
			this.focus = date;
			this.type = "day";
		},
		
		setToday() {
			this.focus = "";
		},
		
		prev() {
			this.$refs.calendar.prev();
		},
		
		next() {
			this.$refs.calendar.next();
		},
		
		updateRange({start, end}) {
			const events = [];
			
			const min = new Date(`${start.date}T00:00:00`);
			const max = new Date(`${end.date}T23:59:59`);
			const days = (max.getTime() - min.getTime()) / 86400000;
			const eventCount = this.rnd(days, days + 20);
			
			for (let i = 0; i < eventCount; i++) {
				const allDay = this.rnd(0, 3) === 0;
				const firstTimestamp = this.rnd(min.getTime(), max.getTime());
				const first = new Date(firstTimestamp - (firstTimestamp % 900000));
				const secondTimestamp = this.rnd(2, allDay ? 288 : 8) * 900000;
				const second = new Date(first.getTime() + secondTimestamp);
				
				events.push({
					name: this.names[this.rnd(0, this.names.length - 1)],
					start: first,
					end: second,
					color: this.colors[this.rnd(0, this.colors.length - 1)],
					timed: !allDay,
				});
			}
			
			this.events = events;
		},
	},
});
</script>

<style lang="scss" scoped>



h3 {
	text-align: center;
	color: #00A460;
	font-size: 21px;
	padding-bottom: 8px;
}

#graph {
	background-color: #F5F5F5;
}

.v-select:checked {
	color: #00A460!important;
}

.stroke {
	margin-left: 20px;
	margin-right: 20px;
	border: 1px solid #475DEB;
}

.v-calendar {
	user-select: none;
	-webkit-user-select: none;
}

.curWeek {
	margin: 0.5em;
}

.v-event-drag-bottom {
	position: absolute;
	left: 0;
	right: 0;
	bottom: 4px;
	height: 4px;
	cursor: ns-resize;
}

.v-event-drag-bottom::after {
	display: none;
	position: absolute;
	left: 50%;
	height: 4px;
	border-top: 1px solid white;
	border-bottom: 1px solid white;
	width: 20px;
	margin-left: -10px;
	opacity: 0.8;
	content: "";
}

.v-event-timed:hover .v-event-drag-bottom::after {
	display: block;
}

.v-current-time {
	height: 1px;
	background-color: red;
	position: absolute;
	left: -1px;
	right: 0;
	pointer-events: none;
	
	&.first::after {
		content: "";
		position: absolute;
		background-color: red;
		width: 7px;
		height: 7px;
		border-radius: 3.5px;
		margin-top: -3px;
		margin-left: -3px;
	}
	
	.v-current-time-time {
		display: none;
	}
	
	&.first .v-current-time-time {
		display: block;
		position: absolute;
		left: -60px;
		color: red;
		font-size: 10px;
		padding: 1px;
		background-color: white;
		width: 50px;
		height: 20px;
		text-align: right;
		top: -9px;
	}
}

.marg {
	margin: 4px;
	color: #000;
}

</style>
