DROP TABLE IF EXISTS
    radiosonde.radiosonde_launch_station;

CREATE TABLE radiosonde.radiosonde_launch_station (
    id varchar(25),
    created_date_time_stamp datetime,
	latitude decimal(15,12),
	longitude decimal(15,12),
	elevation decimal(8,2),
	us_state varchar(10),
	station_name varchar(50),
	fips varchar(10),
	station_call varchar(10),
	wmo_id varchar(25)
);