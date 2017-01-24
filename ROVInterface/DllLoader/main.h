#pragma once
#include <string>

class main
{
private:
	main();
	~main();

	bool _loaded = false;
	const std::string path = "AEgir.dll";
public:
	bool loaded();	// Just giving the _loaded value
	bool init();	// Find the dll and load it
	
};