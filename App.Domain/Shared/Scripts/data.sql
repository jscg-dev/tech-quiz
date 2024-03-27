/**
fuente de datos ficticios
https://json-generator.com/
{
  students: [
    '{{repeat(120, 122)}}',
    {
      name: '{{firstName()}} {{surname()}}',
      dni: '{{guid()}}'
    }
  ],
    groups: [
    '{{repeat(5, 7)}}',
    {
      _id: '{{index()}}',
      name: function() { return 'Group ' + (+this._id + 1); }
    }
  ],
  courses: [
    '{{repeat(5, 7)}}',
    {
      _id: '{{index()}}',
      name: function() { return 'Course ' + (+this._id + 1); }
    }
  ]
}

**/
if (select count(*) from dbo.users) = 0
begin
	insert into dbo.users ([name], [password])
	values ('Admin', 'Admin123')
end

go

if (select count(*) from dbo.students) = 0
begin
	declare @students varchar(max) = N'
	[
		{
			"name": "Holly Patton",
			"dni": "15372985-04b9-4cdc-b0be-4aaa3bae10d0"
		},
		{
			"name": "Freeman Davidson",
			"dni": "b511f0a5-ea48-4477-95c5-f6fe6fec3f7a"
		},
		{
			"name": "Audrey Mejia",
			"dni": "e8ed2d02-fb24-4270-bc8d-9ca123f5d82f"
		},
		{
			"name": "Chang Manning",
			"dni": "fedf5197-680d-4336-abde-d93ca81936b4"
		},
		{
			"name": "Snow Valdez",
			"dni": "c2b389b2-533b-4df0-a4a7-041aa4356a7b"
		},
		{
			"name": "Leola Dorsey",
			"dni": "19d3af49-5094-4c4f-a88b-38ef6734f817"
		},
		{
			"name": "Regina Gutierrez",
			"dni": "fd1da7d7-0274-438f-bbe3-f035e912a7e0"
		},
		{
			"name": "Ina Brooks",
			"dni": "1c3d0f8a-9d4e-4e8e-a595-a2802e55cfb2"
		},
		{
			"name": "Concetta Barr",
			"dni": "00ed8ad8-d8ac-488c-aed6-73744e6e545b"
		},
		{
			"name": "Patti Cole",
			"dni": "c8f4a30a-f985-4cd1-9926-257c0e9d269a"
		},
		{
			"name": "Dolly Downs",
			"dni": "c4c0d808-4319-4667-abe8-1f0b63dd3804"
		},
		{
			"name": "Colleen Andrews",
			"dni": "76e65ad8-376e-41eb-ae50-28e98c5054d5"
		},
		{
			"name": "Rivas Larson",
			"dni": "f1b71687-7e80-4a21-a09e-0cb4dca923b9"
		},
		{
			"name": "Carlene Hurst",
			"dni": "8a228a9a-365d-4272-8741-5144ebd8738e"
		},
		{
			"name": "Luz Horne",
			"dni": "8cd12fec-b2f9-4bc0-a34a-4ca6c5077373"
		},
		{
			"name": "England Chase",
			"dni": "096d15e5-d99f-49f8-9b24-b5417770c3f2"
		},
		{
			"name": "Lillie Hartman",
			"dni": "34c6a1cb-fa6c-4b38-a11f-7fafc32e91f9"
		},
		{
			"name": "Aguilar Mcneil",
			"dni": "b2640bb8-5d0d-4ea0-bff7-db448679ede9"
		},
		{
			"name": "Schroeder Pickett",
			"dni": "e9918089-3ff8-411a-b71b-b995f4ecee92"
		},
		{
			"name": "Patricia Brock",
			"dni": "d82d5407-4975-468c-a580-8dd6bd987911"
		},
		{
			"name": "Parrish Cooley",
			"dni": "6cb0ea91-f16c-4711-bfd0-c621ebbd3755"
		},
		{
			"name": "Odonnell Navarro",
			"dni": "fffcc60b-0356-44c7-b738-4dceb1873f9f"
		},
		{
			"name": "Tabitha Ellis",
			"dni": "a6140f4a-4f58-42e3-a651-1f6563a38a65"
		},
		{
			"name": "Johanna Whitfield",
			"dni": "8b6093a2-fd86-4ed2-820b-3f6ec33bfdf5"
		},
		{
			"name": "Milagros Flores",
			"dni": "c8aee277-b9f9-4318-bd0a-9614c5bca9ce"
		},
		{
			"name": "Lelia Booth",
			"dni": "7f085eea-4ba7-483c-b2d8-c4d98d292fba"
		},
		{
			"name": "Laura Ruiz",
			"dni": "b3804411-2ed8-4d08-98c7-4932ac451cc7"
		},
		{
			"name": "Elvia Harmon",
			"dni": "dff81f65-036d-47a7-9df8-76d4bc3229bd"
		},
		{
			"name": "Whitaker Ray",
			"dni": "ea399cbb-f5d4-428c-bfaa-31ba0e09a1ff"
		},
		{
			"name": "Terri Byrd",
			"dni": "219c3c34-fcca-46d9-8190-dcdb002db2ca"
		},
		{
			"name": "Cruz Berry",
			"dni": "62be71f1-9e31-4da5-a370-e54d10688ea5"
		},
		{
			"name": "Kathy Kirk",
			"dni": "46402264-3f10-4142-ad00-9de3fc59e981"
		},
		{
			"name": "Shelley Joyce",
			"dni": "14f4de1a-e755-4c06-b4ff-b59fbbe0d204"
		},
		{
			"name": "Willis Myers",
			"dni": "9d0aebcb-7323-46e1-88b1-a9989a487d6c"
		},
		{
			"name": "Coleman Turner",
			"dni": "bc4fc52c-743e-442d-9afc-01b44a919813"
		},
		{
			"name": "Maddox Pugh",
			"dni": "735ae02c-f692-4dc9-bb72-3058f3eaeb22"
		},
		{
			"name": "Knight Wolf",
			"dni": "fe817077-25fc-4b82-a403-4a32f7726c66"
		},
		{
			"name": "Walter Delacruz",
			"dni": "025234df-b7a0-4854-9c46-bb95a366284a"
		},
		{
			"name": "Martinez Atkins",
			"dni": "cb09e555-3cdd-4b68-9386-aa358c1f8097"
		},
		{
			"name": "Carver Mccall",
			"dni": "97678b8f-f245-4061-abf5-9e0f78a99171"
		},
		{
			"name": "Morton Harrington",
			"dni": "6082e64e-da0e-463e-a566-3aea425b67ad"
		},
		{
			"name": "Gentry Vasquez",
			"dni": "665e1b66-9f14-4a1d-9393-584cb69dffcf"
		},
		{
			"name": "Joanna Merritt",
			"dni": "72dbaa38-e000-474c-808f-d73a04f03cca"
		},
		{
			"name": "Blake Carr",
			"dni": "dcde6f2c-f74f-4a84-8e3e-66f5e87d83d5"
		},
		{
			"name": "Mullins Hubbard",
			"dni": "06a27aaf-d2cf-4893-9dbf-ffcd96abfe70"
		},
		{
			"name": "Vicki Gay",
			"dni": "03984bab-5114-450a-aca0-a389eb633603"
		},
		{
			"name": "Shelia Roy",
			"dni": "aa31aa00-32bc-494b-99f2-04fa1d7fcde3"
		},
		{
			"name": "Verna Macdonald",
			"dni": "13716349-3483-49a7-8bd3-35be8683f68b"
		},
		{
			"name": "Olsen Garrett",
			"dni": "e9294a1b-7425-4ba1-8436-b0ee7abfce57"
		},
		{
			"name": "Kidd Hahn",
			"dni": "a8db37cb-e49e-434b-bb7a-3ce912adcb26"
		},
		{
			"name": "Clarissa Oconnor",
			"dni": "abce7f60-a704-4be0-a0ac-e023978214dd"
		},
		{
			"name": "Colette Ochoa",
			"dni": "d2782e70-017d-4d89-b76b-74473b4b1621"
		},
		{
			"name": "Patterson Mclean",
			"dni": "c662f87f-3465-4d5e-9deb-72ce7f12fdee"
		},
		{
			"name": "Aida Odonnell",
			"dni": "41d113bf-f4a4-4e12-85af-2d1dc9d1b3cb"
		},
		{
			"name": "Anita Young",
			"dni": "2863d97e-b565-4fc4-b785-098e655bdb8b"
		},
		{
			"name": "Coffey Goff",
			"dni": "375f5b25-3cdf-4a5c-b371-a041ca504022"
		},
		{
			"name": "Alexandra Nelson",
			"dni": "d9e89ed5-e68e-4f44-ae51-e5827f21db12"
		},
		{
			"name": "Carole Rosales",
			"dni": "f5c41616-702d-487b-a96e-f3ea95272ab4"
		},
		{
			"name": "Lynnette Wooten",
			"dni": "6280b7ef-b493-4c1c-8bdb-3e48105e1612"
		},
		{
			"name": "Lynn Bauer",
			"dni": "520df2b2-ddf1-464a-89f3-446cd8eb492b"
		},
		{
			"name": "Denise Daniels",
			"dni": "90faba2e-4fb4-4ba2-af4b-359fa491eb8f"
		},
		{
			"name": "Trudy Landry",
			"dni": "65dc4578-f2eb-4854-a37f-2be616f41892"
		},
		{
			"name": "Torres Keller",
			"dni": "d9a0f557-7d18-437b-94fd-85ffc9346275"
		},
		{
			"name": "Kenya Smith",
			"dni": "a2b02d4e-8e10-4b0f-a523-f83954619c19"
		},
		{
			"name": "Swanson Gonzales",
			"dni": "6c799c51-ae41-4997-8329-e85e09fc6100"
		},
		{
			"name": "Tisha Clay",
			"dni": "f8ba624b-620b-413e-8ffd-c5687cdcf6df"
		},
		{
			"name": "Jeanie Zamora",
			"dni": "a18af025-69bd-48f1-b158-df2ee4ad45b1"
		},
		{
			"name": "Marissa Jenkins",
			"dni": "33878807-267b-4d6a-843a-0253d7667436"
		},
		{
			"name": "Mcintosh Bridges",
			"dni": "593948ce-1ced-46c1-821c-865b96f42188"
		},
		{
			"name": "Fuller Brady",
			"dni": "5a901d4f-9f94-49e7-b037-44cd1ee136c3"
		},
		{
			"name": "Beatrice Daniel",
			"dni": "018c5c0c-07ed-494e-b516-be70673bcfc6"
		},
		{
			"name": "Forbes Pena",
			"dni": "a2bfdd85-8992-45c6-aed4-9c7024ee847c"
		},
		{
			"name": "Roxanne Reid",
			"dni": "f4ae4372-170f-4e43-8bd2-572c5c46331b"
		},
		{
			"name": "Leonor Fischer",
			"dni": "2213e54d-a55f-43fa-a971-b6bacfda0ec0"
		},
		{
			"name": "Riley Garza",
			"dni": "e2e0b292-bad1-40b5-bdfa-7dc5dd074511"
		},
		{
			"name": "Clara Boone",
			"dni": "91257c5b-c791-4925-babe-42a418e67a74"
		},
		{
			"name": "Marla Albert",
			"dni": "de706d85-ccf3-47e3-851f-ef61be72200b"
		},
		{
			"name": "Stein Joyner",
			"dni": "a0392cd0-5c0e-4257-a8a2-c79502ed4fa9"
		},
		{
			"name": "Tate Martin",
			"dni": "ad0d1bd0-838a-4c89-9c75-5d91966f0741"
		},
		{
			"name": "Amalia Gould",
			"dni": "7d5fd513-38d6-4bce-bb72-bd25ac499251"
		},
		{
			"name": "Rosetta Rodgers",
			"dni": "8e669ef3-e329-40b0-85a2-3fab4ea937e7"
		},
		{
			"name": "Hunter Mann",
			"dni": "9c3f110a-78c8-47e2-800a-5bf489bcfa15"
		},
		{
			"name": "Becker Payne",
			"dni": "9d17c0b6-5024-4ebd-89a6-da18ae63935b"
		},
		{
			"name": "Ella Castillo",
			"dni": "2093a21a-dc7b-42aa-8ed6-6605684cd03c"
		},
		{
			"name": "Arnold Lindsey",
			"dni": "fbbd2bc2-61b5-4210-82d0-9d9d55cc0e02"
		},
		{
			"name": "Karina Pittman",
			"dni": "9dca6489-9577-4ee9-b7ee-ac2ae20a3e5d"
		},
		{
			"name": "June Baxter",
			"dni": "818570c8-5aca-46d6-82bc-d841a916be6c"
		},
		{
			"name": "Cathleen Robles",
			"dni": "4061442e-0a8c-4e04-897e-8c795a400cda"
		},
		{
			"name": "Lott Graham",
			"dni": "d24fe80d-73c0-4d7e-a21b-9869bc6dd0e6"
		},
		{
			"name": "Nelson England",
			"dni": "48b50b31-f724-4949-87c9-08e9443e8b99"
		},
		{
			"name": "Florence Sexton",
			"dni": "0a15457d-63de-4349-9205-fb547e5f5315"
		},
		{
			"name": "Raymond Obrien",
			"dni": "6538cb8e-b061-4fe1-9717-52588f04e375"
		},
		{
			"name": "Roberta Norton",
			"dni": "9e773d50-5081-4e8f-b33f-0bb3c86e73e1"
		},
		{
			"name": "Staci Conway",
			"dni": "61c32191-328e-49b9-b62e-6c997d50642a"
		},
		{
			"name": "Francesca Owens",
			"dni": "7aa8cb43-76f8-4e67-b62b-de2f8cda7ce4"
		},
		{
			"name": "Nielsen Hoover",
			"dni": "76351f02-8316-4793-812e-b10d5638c86c"
		},
		{
			"name": "Dillon Charles",
			"dni": "be4140c3-cd07-46d1-aa8c-ce8559c63bcf"
		},
		{
			"name": "Andrea Savage",
			"dni": "3a3cb81a-b1a1-4c6d-8794-5a3342c8dd80"
		},
		{
			"name": "Vicky Vazquez",
			"dni": "65a68209-54f1-48de-9986-f29055ea9cec"
		},
		{
			"name": "Marylou Norris",
			"dni": "49443ac4-9ec2-473b-9647-c6b4fe5473b4"
		},
		{
			"name": "Henry Guy",
			"dni": "1d634577-43b2-4b08-b787-1dcce0e54fea"
		},
		{
			"name": "Avery Mcdowell",
			"dni": "a8adc439-f69f-4117-b123-1e0947c893d7"
		},
		{
			"name": "Britt Harrison",
			"dni": "86967b2e-ceb8-4d95-95aa-6e51cd9193f3"
		},
		{
			"name": "Oconnor Leonard",
			"dni": "07dff07a-c08a-4945-b690-f3a9352a0b6d"
		},
		{
			"name": "Berta Tran",
			"dni": "25bc074b-b049-4a58-8768-dc0b6d326915"
		},
		{
			"name": "Mccoy Levy",
			"dni": "3572349c-06c3-4882-92f6-94e47e3d9430"
		},
		{
			"name": "Nichols Cantrell",
			"dni": "c6fc92e9-4d08-46d6-a469-e0e4d3061fc1"
		},
		{
			"name": "Roach Frank",
			"dni": "00d7d1fc-500c-4d13-9f27-224b7878f99b"
		},
		{
			"name": "Cecile English",
			"dni": "ce0fa608-45d7-4371-b071-ad5982748713"
		},
		{
			"name": "Natasha Patterson",
			"dni": "59388616-411d-4ee4-be80-0f2eb6a0f908"
		},
		{
			"name": "Bryant Meadows",
			"dni": "def564f1-e8f4-417c-aa01-0586e9a3ba8a"
		},
		{
			"name": "Gilda Wise",
			"dni": "ebf429d4-1f3b-42f3-8c0e-9f0cbaaa2f65"
		},
		{
			"name": "Harrington Dominguez",
			"dni": "c49e959b-cc9a-4144-9e24-192285bbba72"
		},
		{
			"name": "Callie Mueller",
			"dni": "4e385868-48d9-4e77-aafb-8ac985b9fd58"
		},
		{
			"name": "Hays Stephens",
			"dni": "e8e7aa94-6706-4070-ae8c-a0eda6145888"
		},
		{
			"name": "Wilkins Booker",
			"dni": "94cbd99a-da65-43ac-bb75-e6f4108cec94"
		},
		{
			"name": "Teri Cote",
			"dni": "71cc4ba8-6f60-4460-92b8-b93ebdacace2"
		},
		{
			"name": "Curtis Carroll",
			"dni": "b4f0250e-737f-439b-a47e-542a3cfee976"
		},
		{
			"name": "Earline Santos",
			"dni": "adcb8217-61dd-494f-81d8-f78d3fd0e453"
		},
		{
			"name": "Koch Swanson",
			"dni": "2154932d-6666-442e-8b4b-e80438e8cdfd"
		}
	]
	'
	insert into dbo.students([name], [dni])
	select
		*
	from
		openjson(@students)
	with
	(
		[name] varchar(200),
		[dni] varchar(100)
	)
end

go

if (select count(*) from dbo.groups) = 0
begin
	declare @groups varchar(max) = N'
	[
		{
		  "_id": 0,
		  "name": "Group 1"
		},
		{
		  "_id": 1,
		  "name": "Group 2"
		},
		{
		  "_id": 2,
		  "name": "Group 3"
		},
		{
		  "_id": 3,
		  "name": "Group 4"
		},
		{
		  "_id": 4,
		  "name": "Group 5"
		}
	  ]
	'
	insert into dbo.groups ([name])
	select
		*
	from
		openjson(@groups)
	with
	(
		[name] varchar(100)
	)
end

go

if (select count(*) from dbo.courses) = 0
begin
	declare @courses varchar(max) = N'
	[
		{
		  "_id": 0,
		  "name": "Course 1"
		},
		{
		  "_id": 1,
		  "name": "Course 2"
		},
		{
		  "_id": 2,
		  "name": "Course 3"
		},
		{
		  "_id": 3,
		  "name": "Course 4"
		},
		{
		  "_id": 4,
		  "name": "Course 5"
		},
		{
		  "_id": 5,
		  "name": "Course 6"
		}
	]'

	insert into dbo.courses ([name], [group_id])
	select
		[jarr].[name],
		dbo.groups.id
	from
		openjson(@courses)
	with
	(
		[name]  varchar(100)
	) [jarr]
	inner join
		dbo.groups
	on
		1 = 1
end

go

if (select count(*) from dbo.asignments) = 0
begin
	insert into dbo.asignments ([course_id], [student_id])
	select top 500
		dbo.courses.id [course_id]
		,dbo.students.id [student_id]
	from
		dbo.students
	inner join
		dbo.courses
	on
		1 = 1
end

go

if (select count(*) from dbo.marks) = 0
begin
	insert into dbo.marks ([asignment_id], [mark])
	select
		dbo.asignments.id [asignment_id]
		,3 [mark]
	from
		dbo.asignments
end