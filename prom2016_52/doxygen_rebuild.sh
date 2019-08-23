#!/usr/bin/env bash

echo "#### Clearing old folder DOXYGEN_OUTPUT... ####"
rm -r DOXYGEN_OUTPUT
echo "## Done. ##"

echo "#### Generating new documentaion... ####"
doxygen Doxyfile
echo "## Done. ##"
