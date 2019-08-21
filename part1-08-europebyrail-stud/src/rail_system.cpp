#pragma warning (disable:4786)
#pragma warning (disable:4503)

#include "rail_system.h"

void RailSystem::load_services(const std::string &filename)
{
    std::string line;
    std::vector<std::string> items;
    std::map<std::string, std::list<Service*>>::iterator itServ;
    std::map<std::string, City*>::iterator itCit;

    try
    {
        std::ifstream in(filename);
        if (in.is_open())
            while (getline(in, line))
            {
                items = split(line);
                itServ = outgoing_services.find(items[0]);
                if (itServ != outgoing_services.end())
                    (itServ->second).push_back(new Service(items[1], atoi(items[2].c_str()), atoi(items[3].c_str())));
                else
                    outgoing_services.insert(
                            {items[0], {new Service(items[1], atoi(items[2].c_str()), atoi(items[3].c_str()))}});
                itCit = cities.find(items[0]);
                if (itCit != cities.end())
                    cities.insert({items[0], new City(items[0])});
                itCit = cities.find(items[1]);
                if (itCit != cities.end())
                    cities.insert({items[1], new City(items[1])});
            }
        in.close();
    }
    catch (std::exception)
    {
        throw std::logic_error("");
    }
}

void RailSystem::reset()
{
    for(std::map<std::string, City*>::iterator it = cities.begin(); it != cities.end(); ++it)
    {
        it->second->visited = false;
        it->second->total_distance = 0;
        it->second->total_fee = 0;
        it->second->from_city = "";
    }
}

std::vector<std::string> RailSystem::recover_route(const std::string &city)
{
    return std::vector<std::string>();
}

std::pair<int, int> RailSystem::calc_route(std::string from, std::string to)
{
    return std::pair<int, int>();
}

RailSystem::RailSystem(const std::string &filename)
{
    load_services(filename);
}

RailSystem::~RailSystem()
{
    for(std::map<std::string, City*>::iterator it = cities.begin(); it != cities.end(); ++it)
        delete it->second;
    for(std::map<std::string, std::list<Service*>>::iterator it = outgoing_services.begin(); it != outgoing_services.end(); ++it)
        it->second.erase(it->second.begin(), it->second.end());
}

void RailSystem::output_cheapest_route(const std::string &from, const std::string &to)
{

}

bool RailSystem::is_valid_city(const std::string &name)
{
    return cities.find(name) != cities.end();
}

Route RailSystem::getCheapestRoute(const std::string &from, const std::string &to)
{

}