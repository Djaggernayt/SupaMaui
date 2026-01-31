create policy "Allow authenticated uploads"
on storage.objects
for insert
to authenticated
with check (true);
