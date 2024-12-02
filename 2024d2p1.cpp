#include <iostream>
#include <vector>
#include <string>
#include <fstream>
#include <algorithm>
#include <sstream>

using namespace std;
void readInput(vector<string> &input);
vector<string> splitString(const string &str, char delimiter);

int main()
{
    vector<string> input;
    vector<vector<int>> leves;
    readInput(input);
    leves.resize(input.size());

    for (size_t i = 0; i < input.size(); i++)
    {
        vector<string> splitRes = splitString(input[i], ' ');
        for (size_t j = 0; j < splitRes.size(); j++)
        {
            leves[i].push_back(stoi(splitRes[j]));
        }
    }

    int safes = 0;
    for (size_t i = 0; i < leves.size(); i++)
    {
        bool safe = true;
        bool increasing = true;
        bool decreasing = true;
        for (size_t j = 1; j < leves[i].size(); j++)
        {
            int diff = leves[i][j] - leves[i][j - 1];
            if (abs(diff) < 1 || abs(diff) > 3)
            {
                safe = false;
                break;
            }
            if (diff > 0)
            {
                decreasing = false;
            }
            if (diff < 0)
            {
                increasing = false;
            }
        }
        if (safe && (increasing || decreasing))
        {
            safes++;
        }
    }

    cout << "total: " << safes << endl;
    return 0;
}
vector<string> splitString(const string &str, char delimiter)
{
    vector<string> result;
    istringstream iss(str);
    string token;
    while (getline(iss, token, delimiter))
    {
        result.push_back(token);
    }
    return result;
}
void readInput(vector<string> &input)
{
    string s;
    fstream fs("input.txt");
    while (getline(fs, s))
    {
        input.push_back(s);
    }
    fs.close();
}
