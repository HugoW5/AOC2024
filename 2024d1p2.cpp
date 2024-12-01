#include <iostream>
#include <vector>
#include <string>
#include <fstream>
#include <algorithm>

using namespace std;
void readInput(vector<string> &input, vector<int> &left, vector<int> &right);

int main()
{
    vector<string> input;
    vector<int> left;
    vector<int> right;

    readInput(input, left, right);

    int totalSum = 0;

    for (size_t i = 0; i < left.size(); i++)
    {
        int count = 0;

        for (size_t j = 0; j < right.size(); j++)
        {
            if (left[i] == right[j])
            {
                count++;
            }
        }
                cout << right[i] << " - " << count << '\n';
        totalSum += (count * left[i]);
    }
    cout << "total sum: " << totalSum << endl;

    return 0;
}

void readInput(vector<string> &input, vector<int> &left, vector<int> &right)
{
    string s;
    fstream fs("input.txt");
    while (getline(fs, s))
    {
        left.push_back(stoi(s.substr(0, s.find(' '))));
        right.push_back(stoi(s.substr(s.find(' '), s.size())));
    }
    fs.close();
}
