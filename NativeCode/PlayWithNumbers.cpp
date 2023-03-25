#include "pch.h"
#include "PlayWithNumbers.h"
#include "PlayWithNumbers.g.cpp"

namespace winrt::NativeCode::implementation
{
    int32_t PlayWithNumbers::Add(int32_t num1, int32_t num2)
    {
        return num1 + num2;
    }
}