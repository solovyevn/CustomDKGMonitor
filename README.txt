CustomDKGMonitor
================

Small tool for Diesel Generaror Set (DGS) monitoring via Datakom DKG-207 Automatic Mains Failure Unit (AMFU). Might work with other DKG series products, but tested with DKG-207 only. It addresses the disadvantages of Datakom's own Rainbow-Monitor program - lack of sound alarm when DGS is started and lack of sound alarm or any other notification when the connection between monitoring PC and AMFU fails, discovered by its use for some period of time.

Due to unknown data exchange format, after studying the exchange, the coolant temperature and AMFU device date and time position in data frames were discovered, which serve as indicators for CustomDKGMonitor. When the DGS is started and running the coolant temperature will raise. Monitoring the coolant temperature allows CustomDKGMonitor to identify if DGS is started and play a sound alarm. Monitoring lower coolant temperature boundary is important for cold climates, where it can freeze and prevent DGS lauch at needed moment. CustomDKGMonitor also monitors data exchange and if data is absent raise an alarm on connection failure. See more details in "CustomDKGMonitor_Operation_Manual.doc" file in the program folder.

I'm in no way affiliated with Datakom or their products.

All product and company names are trademarks™ or registered® trademarks of their respective holders. Use of them does not imply any affiliation with or endorsement by them.


Requirements
============

 - .NET Framework 3.5


Installation & Usage
====================

No installation step is required, just copy 'CustomDKGMonitor' folder to your machine and see "CustomDKGMonitor_Operation_Manual.doc" for further guidance.


LICENSE
=======

Copyright (c) 2014, Nikita Solovyev
All rights reserved.

Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:

1. Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.

2. Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.

3. Neither the name of the copyright holder nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.