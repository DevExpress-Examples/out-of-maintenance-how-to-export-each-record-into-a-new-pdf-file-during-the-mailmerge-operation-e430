Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace MailMergeEachRecordSeparatePDF
	Public Class DataHelper

		 Private Shared firstName() As String = { "Nancy", "Andrew", "Janet", "Margaret", "Steven", "Michael", "Robert", "Laura", "Anne" }
		 Private Shared lastName() As String = { "Davolio", "Fuller", "Leverling", "Peacock", "Buchanan", "Suyama", "King", "Callahan", "Dodsworth" }
		 Private Shared city() As String = { "Seattle", "Tacoma", "Kirkland", "Redmond", "London", "London", "London", "Seattle", "London" }
		 Private Shared country() As String = { "USA", "USA", "USA", "USA", "UK", "UK", "UK", "USA", "UK" }
		 Private Shared address() As String = { "507 - 20th Ave. E. Apt. 2A", "908 W. Capital Way", "722 Moss Bay Blvd.", "4110 Old Redmond Rd.", "14 Garrett Hill", "Coventry House Miner Rd.", "Edgeham Hollow Winchester Way", "4726 - 11th Ave. N.E.", "7 Houndstooth Rd." }
		 Private Shared position() As String = { "Sales Representative", "Vice President, Sales", "Sales Representative", "Sales Representative", "Sales Manager", "Sales Representative", "Sales Representative", "Inside Sales Coordinator", "Sales Representative" }
		 Private Shared gender() As Char = { "F"c, "M"c, "F"c, "F"c, "M"c, "M"c, "M"c, "F"c, "F"c }
		 Private Shared phone() As String = { "(206) 555-9857", "(206) 555-9482", "(206) 555-3412", "(206) 555-8122", "(71) 555-4848", "(71) 555-7773", "(71) 555-5598", "(206) 555-1189", "(71) 555-4444" }
		 Private Shared companyName() As String = { "Consolidated Holdings", "Around the Horn", "North/South", "Island Trading", "White Clover Markets", "Trail's Head Gourmet Provisioners", "The Cracker Box", "The Big Cheese", "Rattlesnake Canyon Grocery", "Split Rail Beer & Ale", "Hungry Coyote Import Store", "Great Lakes Food Market" }

		 Private Shared Function CreateEmployee(ByVal seed As Integer) As Employee
			Dim result As New Employee()
			Dim rnd As New Random(seed)
			Dim countryIndex As Integer = rnd.Next(0, country.Length)
			result.Country = country(countryIndex)
			result.Address = address(countryIndex)
			result.City = city(countryIndex)
			result.LastName = lastName(rnd.Next(0, lastName.Length))
			Dim firstNameIndex As Integer = rnd.Next(0, firstName.Length)
			result.FirstName = firstName(firstNameIndex)
			result.Gender = gender(firstNameIndex)
			result.HiringDate = DateTime.Now.AddDays(-(rnd.Next(0, 2000)))
			result.Position = position(rnd.Next(0, position.Length))
			result.Phone = phone(rnd.Next(0, phone.Length))
			result.CompanyName = companyName(rnd.Next(0, companyName.Length))
			result.HRManagerName = String.Format("{0} {1}", firstName(rnd.Next(0, firstName.Length)), lastName(rnd.Next(0, lastName.Length)))
			Return result
		 End Function

		 Public Shared Function GenerateEmployeeList() As List(Of Employee)
			 Dim employees As New List(Of Employee)()
			 For i As Integer = 0 To 9
				 employees.Add(CreateEmployee(i))
			 Next i
			 Return employees
		 End Function

	End Class

	Public Class Employee
		Private firstName_Renamed As String
		Private lastName_Renamed As String
		Private hiringDate_Renamed As DateTime
		Private address_Renamed As String
		Private city_Renamed As String
		Private country_Renamed As String
		Private position_Renamed As String
		Private companyName_Renamed As String
		Private gender_Renamed As Char
		Private phone_Renamed As String
		Private hrManagerName_Renamed As String

		Public Property FirstName() As String
			Get
				Return firstName_Renamed
			End Get
			Set(ByVal value As String)
				firstName_Renamed = value
			End Set
		End Property
		Public Property LastName() As String
			Get
				Return lastName_Renamed
			End Get
			Set(ByVal value As String)
				lastName_Renamed = value
			End Set
		End Property
		Public Property HiringDate() As DateTime
			Get
				Return hiringDate_Renamed
			End Get
			Set(ByVal value As DateTime)
				hiringDate_Renamed = value
			End Set
		End Property
		Public Property Address() As String
			Get
				Return address_Renamed
			End Get
			Set(ByVal value As String)
				address_Renamed = value
			End Set
		End Property
		Public Property City() As String
			Get
				Return city_Renamed
			End Get
			Set(ByVal value As String)
				city_Renamed = value
			End Set
		End Property
		Public Property Country() As String
			Get
				Return country_Renamed
			End Get
			Set(ByVal value As String)
				country_Renamed = value
			End Set
		End Property
		Public Property Position() As String
			Get
				Return position_Renamed
			End Get
			Set(ByVal value As String)
				position_Renamed = value
			End Set
		End Property
		Public Property CompanyName() As String
			Get
				Return companyName_Renamed
			End Get
			Set(ByVal value As String)
				companyName_Renamed = value
			End Set
		End Property
		Public Property Gender() As Char
			Get
				Return gender_Renamed
			End Get
			Set(ByVal value As Char)
				gender_Renamed = value
			End Set
		End Property
		Public Property Phone() As String
			Get
				Return phone_Renamed
			End Get
			Set(ByVal value As String)
				phone_Renamed = value
			End Set
		End Property
		Public Property HRManagerName() As String
			Get
				Return hrManagerName_Renamed
			End Get
			Set(ByVal value As String)
				hrManagerName_Renamed = value
			End Set
		End Property
	End Class
End Namespace
