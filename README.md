# Energyhelpline.TarrifCalculator

To run this console application simply clone the repository.

Then, go to "application.json" and edit the "FromAddress" to reflect the address you are firing
any messages from plus the credentials "Username" and "Password". 

Also set the "ToAddress" and "SmtpServer", "Port" settings.

Then in powershell, go to \Energyhelpline.TariffCalculator\src\Energyhelpline.TariffCalculator
and run:

dotnet run

The application results should be printed on the prompt as well as sent to your destination email:

C:\Projects\Energyhelpline.TariffCalculator\src\Energyhelpline.TariffCalculator [master +0 ~2 -0 !]> dotnet run

Project Energyhelpline.TariffCalculator (.NETCoreApp,Version=v1.0) was previously compiled. Skipping compilation.

Date: 8/29/2017 2:51:19 PM

Gas usage: 2000 kWh

Electricity usage: 4000 kWh

Cheapest tariff: Energy Saver

Annual cost: £3381.37
