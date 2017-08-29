# Energyhelpline.TarrifCalculator

energyhelpline.com Coding Exercise – Best Tariff Quote Tool
Background
Energy Helpline provides millions of customers each year with quotes to allow them to choose the cheapest tariff for the next year. This task requires you to create a very simple version of a tool to generate these quotes based on a customer's energy usage (measured in kilowatt-hours). The real one is much more complex of course!
The basic calculation for both gas and electricity is:
Annual cost (£) = tariff unit rate (£/kWh) * annual usage(kWh)
Some tariffs' rates don't change while a customer is on them. Others have an expiry date, after which the customer is placed on a different (usually more expensive) rate. This means that the quoted cost of a year's usage will vary depending on when the quote is made.
Task
Write a console application that produces a quote for the cheapest tariff (using the list of supplied tariffs below in the ‘Tariff data’ table) and sends it to the customer by email.
Use your tool to produce a quote for a user with an annual gas usage of 2000 kWh and an electricity usage of 4000 kWh.  The tool should calculate the quote starting from the day the tool is run, or provide a mechanism for specifying the start day for the quote. The customer's email address is devjobs@energyhelpline.com.  When you have done this send your source code to devjobs@energyhelpline.com and we will discuss your solution. 
The quote should be formatted as follows:
Date: <date > Gas usage: <gas usage> Electricity usage: <electricity usage> Cheapest tariff: <cheapest tariff> Annual cost: £<annual cost>
The items surrounded by angle brackets should be replaced by:
<date> date and time the quote was issued
<gas usage> gas usage in kWh
<electricity usage> electricity usage in kWh
<cheapest tariff> the name of the cheapest tariff
<annual cost> the total cost of the cheapest tariff for the energy usage in £
Tariff data
Tariff name	Gas initial unit rate (£/kWh)	Gas final unit rate (£/kWh)	Electricity initial unit rate (£/kWh)	Electricity final unit rate (£/kWh)	Initial rate expiration date (DD/MM/YYYY)
Energy Saver	0.25	0.50	0.30	0.60	01/09/2017
Discount Energy	0.20	0.75	0.20	0.90	10/10/2017
Standard	0.65		0.80		None
Save Online	0.25	0.60	0.10	1.00	23/08/2017
Worked example of calculation of annual cost of tariff:
For a house using 1500 kWh units of gas and 3000 kWh units of electricity
For the following tariff:
Tariff name	Gas initial unit rate (£/kWh)	Gas final unit rate (£/kWh)	Electricity initial unit rate (£/kWh)	Electricity final unit rate (£/kWh)	Initial rate expiration date (DD/MM/YYYY)
Energy Saver	0.25	0.50	0.30	0.60	01/01/2018

For a quote generated on 01/08/2017 the annual cost for 'Energy Saver' is worked out as follows:
Time on initial unit rate: There are 153 days between the quote date (01/08/2017) and the initial rate expiration date (01/01/2018)
Initial unit rate gas cost: ((153/365)*1500)*0.25 = 157.19
Initial unit rate electricity cost: ((153/365)*3000)*0.3 = 377.26
Time on final unit rate: 365 – 153 = 212
Final unit rate gas cost: ((212/365)*1500)*0.5 = 435.62
Final unit rate electricity cost: ((212/365)*3000)*0.6 = 1,045.48
Final cost	=	157.19 + 377.26 + 435.62 + 1,045.48
		=	2,015.55
