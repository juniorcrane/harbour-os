#include <string>
#include <iostream>
#include <fstream>
#include <iostream>
#include <sstream>
#include <cstdlib>

std::string _html;
std::string _game1;
std::string _game2;
std::string _game3;
std::string _game4;
std::string _game5;
std::string _game6;
std::string _game7;
std::string _game8;
std::string _game9;
std::string _game10;
size_t _place1;
size_t _place2;
size_t _place3;
size_t _place4;
size_t _place5;
size_t _place6;
size_t _place7;
size_t _place8;
size_t _place9;
size_t _place10;
size_t _place11;
size_t _place12;
size_t _place13;
size_t _place14;
size_t _place15;
size_t _place16;
size_t _place17;
size_t _place18;
size_t _place19;
size_t _place20;
size_t _place21;
size_t _place22;
size_t _place23;

int main(int argc, char* argv[]) {
    std::system("rm list.html");
    std::system("rm game.txt");
    std::system("wget -O list.html https://itch.io/games/platform-web");
    std::ifstream in("list.html");
    std::stringstream buffer;
    buffer << in.rdbuf();
    std::string _html = buffer.str();

    _place1 = _html.find("YouTube!");
    _place2 = _html.find("href", _place1) + 6;
    _place3 = _html.find('"', _place2) - 2;
    _game1 = _html.substr(_place2, _place3 - _place2);

    _place4 = _html.find("href", _place3) + 6;
    _place5 = _html.find("href", _place4) + 6;
    _place6 = _html.find("href", _place5) + 6;
    _place7 = _html.find("href", _place6) + 6;
    _place8 = _html.find('"', _place7);
    _game2 = _html.substr(_place7, _place8 - _place7);

    _place9 = _html.find("href", _place8) + 6;
    _place10 = _html.find("href", _place9) + 6;
    _place11 = _html.find("href", _place10) + 6;
    _place12 = _html.find("href", _place11) + 6;
    _place13 = _html.find('"', _place12);
    _game3 = _html.substr(_place12, _place13 - _place12);

    _place14 = _html.find("href", _place13) + 6;
    _place15 = _html.find("href", _place14) + 6;
    _place16 = _html.find("href", _place15) + 6;
    _place17 = _html.find("href", _place16) + 6;
    _place18 = _html.find('"', _place17);
    _game4 = _html.substr(_place17, _place18 - _place17);

    _place19 = _html.find("href", _place18) + 6;
    _place20 = _html.find("href", _place19) + 6;
    _place21 = _html.find("href", _place20) + 6;
    _place22 = _html.find("href", _place21) + 6;
    _place23 = _html.find('"', _place22);
    _game5 = _html.substr(_place22, _place23 - _place22);

    std::ofstream out("game.txt");
    out << _game1 + ", " + _game2 + ", " + _game3 + ", " + _game4 + ", " + _game5;
}
