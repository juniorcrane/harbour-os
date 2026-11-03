#include <string>
#include <iostream>
#include <fstream>
#include <iostream>
#include <sstream>
#include <cstdlib>

bool _loop = true;
std::string _html;
std::string _url;
std::string _gameUrl;
std::string _finalCommand;
size_t _place0;
size_t _place1;

int main(int argc, char* argv[]) {
    if (argc < 2) {
        std::cout << "No URL provided!";
        std::cout << "\n";
        std::cout << "Try again as: './launchItch <URL>'.";
    } else {
        std:system("rm game.html");

        std::string _url = argv[1];

        std::system(("wget -O game.html " + _url).c_str());

        std::ifstream in("game.html");
        std::stringstream buffer;
        buffer << in.rdbuf();
        std::string _html = buffer.str();

        _place0 = _html.find("https://html-classic.itch.zone/");
        _place1 = _html.find("index.html", _place0) + 10;
        _gameUrl = _html.substr(_place0, _place1 - _place0);

        if (_gameUrl.contains(' ') == true)
        {
            _place1 = _html.find('"', _place0);
        }

        _gameUrl = _html.substr(_place0, _place1 - _place0);

        _finalCommand = "cage -- chromium --kiosk --app=" + _gameUrl;


        std::system((_finalCommand).c_str());
    }
}
