#include "pch.h"
#include "example.h"

TEST(TestCaseName, TestName) {
  EXPECT_EQ(1, 1);
  EXPECT_TRUE(true);
}

TEST(example, add)
{
	double result;
	result = add_numbers(1.0, 2.0);
	ASSERT_EQ(result, 3.0);
}

TEST(example, subtract)
{
	double result;
	result = subtractnumbers(1.0, 2.0);
	ASSERT_EQ(result, 3.0);
}