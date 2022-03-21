import HomePage from "./Home";

import React from 'react';
import { render, screen } from '@testing-library/react';


test('HomePage should have a title of ,,Amazons of Volleyball,, v1', async ()=>
{
    render(<HomePage />);
    const headerText: HTMLElement = screen.getByText(/Amazons of Volleyball/i);
    expect(headerText).toBeInTheDocument;
});

test('HomePage should have a title of ,,Amazons of Volleyball,, v2', async ()=>
{
    const {findByText} = render(<HomePage />);
    await findByText("Amazons of Volleyball")
});

test('HomePage should have a icon with a title ,,Add new player,,', async ()=>
{
    const {findByTitle} = render(<HomePage />);
    await findByTitle("Add new player")
});

test('HomePage should have an item with text ,,Nikola Radosová,,', async ()=>
{
    const palyers: string[] = ['Nikola Radosová'];

    const {findByText} = render(<HomePage />);
    await findByText("Nikola Radosová")
});

test('HomePage should have an item with text in array', async ()=>
{
    const names: string[] = ['Nikola Radosová', 'Tanja Matic','Jaqueline Carvalho'];

    const {findByText} = render(<HomePage />);
    await findByText(names[0])
    await findByText(names[1])
    await findByText(names[2])
});
