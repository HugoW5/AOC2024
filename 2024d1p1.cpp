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
    sort(left.begin(), left.end());
    sort(right.begin(), right.end());

    int sum = 0;
    for (size_t i = 0; i < right.size(); i++)
    {
        sum += max(right[i], left[i]) - min(right[i], left[i]);
    }
        cout << "sum: " << sum << endl;
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
